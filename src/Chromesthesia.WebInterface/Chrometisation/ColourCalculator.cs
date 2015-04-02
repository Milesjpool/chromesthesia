using System.Collections.Generic;
using System.Drawing;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;

namespace Chromesthesia.WebInterface.Chrometisation
{
	public class ColourCalculator
	{
		private const int MetadataWeighting = 100;
		private const int GenderWeighting = 50;
		private const int DanceabilityWeighting = 50;
		private const int AcousticityWeighting = 30;
		private const int AggressiveWeighting = 30;
		private readonly List<WeightedColour> _weightedColours = new List<WeightedColour>();
		private Analysis _analysis;

		public Color From(Analysis analysis)
		{
			_analysis = analysis;
			GetMetadataAspect(MetadataWeighting);
			GetGenderAspect(GenderWeighting);
			GetDanceabilityAspect(DanceabilityWeighting);
			GetAcousticityAspect(AcousticityWeighting);
			GetAggressiveAspect(AggressiveWeighting);
			return ColorHandling.Aggregate(_weightedColours);
		}

		private void GetMetadataAspect(int weight)
		{
			var aggregatedMetadata = new MetadataAnalysis(_analysis).Aggregate();
			var colours = ColorHandling.GetColoursIn(aggregatedMetadata);
			_weightedColours.AddList(colours, weight);
		}

		private void GetDanceabilityAspect(int weight)
		{
			var danceability = _analysis.highlevel.danceability;
			var danceabilityWeight = danceability.probability * weight;
			_weightedColours.Add(danceability.value.ToLower().Equals("danceable")
														 ? new WeightedColour(Color.Red, danceabilityWeight)
														 : new WeightedColour(Color.Turquoise, danceabilityWeight));
		}

		private void GetGenderAspect(int weight)
		{
			var gender = _analysis.highlevel.gender;
			var genderWeight = gender.probability * weight;
			_weightedColours.Add(gender.value.ToLower().Equals("female")
														? new WeightedColour(Color.Purple, genderWeight)
														: new WeightedColour(Color.Orange, genderWeight));
		}

		private void GetAcousticityAspect(int weight)
		{
			var acousticity = _analysis.highlevel.mood_acoustic;
			var acousticityWeight = acousticity.probability * weight;
			_weightedColours.Add(acousticity.value.ToLower().Equals("acoustic")
														? new WeightedColour(Color.Goldenrod, acousticityWeight)
														: new WeightedColour(Color.Maroon, acousticityWeight));
		}

		private void GetAggressiveAspect(int weight)
		{
			var aggressive = _analysis.highlevel.mood_aggressive;
			var aggressiveWeight = aggressive.probability * weight;
			_weightedColours.Add(aggressive.value.ToLower().Equals("aggressive")
														? new WeightedColour(Color.Black, aggressiveWeight)
														: new WeightedColour(Color.White, aggressiveWeight));
		}
	}
}