using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;
using Chromesthesia.WebInterface.Chrometisation;

namespace Chromesthesia.WebInterface.Services
{
	public class PredominantPropertyColourCalculator : IColourCalculator
	{
		private const int MetadataWeighting = 100;
		private const int AudioWeighting = 100;
		private List<WeightedColour> _weightedColours = new List<WeightedColour>();

		public Color From(Analysis analysis)
		{
			var metadataAnalysis = new MetadataAnalysis(analysis);
			_weightedColours.AddList(metadataAnalysis.GetColours(), MetadataWeighting);

			var audioAnalysis = new AudioAnalysis(analysis);
			_weightedColours.AddList(audioAnalysis.GetPredominantColours(), AudioWeighting);

			var aggregatedColour = ColorHandling.Aggregate(_weightedColours);
			return ColorHandling.ExaggerateColour(1,aggregatedColour);
		}
	}

	public class AudioAnalysis
	{
		private readonly Analysis _analysis;
		private readonly Dictionary<string, Color> PropertyColors = new Dictionary<string, Color>
			{
				{"danceable",Color.Red},
				{"not_danceable",Color.CornflowerBlue},
				{"female",Color.Purple},
				{"male",Color.Green},
				{"acoustic",Color.Orange},
				{"not_acoustic",Color.Turquoise},
				{"aggressive",Color.Black},
				{"not_aggressive",Color.LavenderBlush},
				{"electronic",Color.Yellow},
				{"not_electronic",Color.Indigo},
				{"happy",Color.DeepSkyBlue},
				{"not_happy",Color.Maroon},
				{"party",Color.DeepPink},
				{"not_party",Color.DarkOrange},
				{"relaxed",Color.GreenYellow},
				{"not_relaxed",Color.Violet},
				{"sad",Color.MidnightBlue},
				{"not_sad",Color.DodgerBlue},
				{"",Color.Black},
			};

		public AudioAnalysis(Analysis analysis)
		{
			_analysis = analysis;
		}

		public List<WeightedColour> GetPredominantColours()
		{
			var predoninantProperties = GetPredominantProperties();
			var predominantColors = ColoursFrom(predoninantProperties);
			return predominantColors;
		}

		private List<Property> GetPredominantProperties()
		{
			var highLevel = _analysis.highlevel;

			var properties = AllProperties(highLevel);

			var predominantProperites = new List<Property>();
			foreach (var property in properties)
			{
				if (predominantProperites.Count < 3) predominantProperites.Add(property);
				else
				{
					if (predominantProperites[0].Probability < property.Probability) predominantProperites[0] = property;
					else if (predominantProperites[1].Probability < property.Probability) predominantProperites[1] = property;
					else if (predominantProperites[2].Probability < property.Probability) predominantProperites[2] = property;
				}
			}
			return predominantProperites;
		}

		private static List<Property> AllProperties(Analysis.HighLevel highLevel)
		{
			return new List<Property> {
				new Property(highLevel.danceability),
				new Property(highLevel.gender),
				new Property(highLevel.mood_acoustic),
				new Property(highLevel.mood_aggressive),
				new Property(highLevel.mood_electronic),
				new Property(highLevel.mood_happy),
				new Property(highLevel.mood_party),
				new Property(highLevel.mood_relaxed),
				new Property(highLevel.mood_sad)
			};
		}

		private List<WeightedColour> ColoursFrom(List<Property> properties)
		{
			return properties.Select(p => new WeightedColour(PropertyColors[p.Name], p.Probability)).ToList();
		}
	}

	internal class Property
	{
		public string Name { get; set; }
		public double Probability { get; set; }

		public Property(dynamic property)
		{
			Name = property.value;
			Probability = property.probability;
		}
	}
}