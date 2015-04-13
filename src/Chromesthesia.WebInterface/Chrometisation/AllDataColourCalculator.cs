using System;
using System.Collections.Generic;
using System.Drawing;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;

namespace Chromesthesia.WebInterface.Chrometisation
{
	public class AllDataColourCalculator : IColourCalculator
	{
		private const int MetadataWeighting = 100;
		private const int GenderWeighting = 50;
		private const int DanceabilityWeighting = 50;
		private const int AcousticityWeighting = 50;
		private const int AggressiveWeighting = 50;
		private const int ElectronicWeighting = 50;
		private const int HappyWeighting = 50;
		private const int PartyWeighting = 50;
		private const int RelaxedWeighting = 50;
		private const int SadWeighting = 50;
		private readonly List<WeightedColour> _weightedColours = new List<WeightedColour>();
		private Analysis _analysis;

		public Color From(Analysis analysis)
		{
			_analysis = analysis;
			var metadataAnalysis = new MetadataAnalysis(analysis);
			_weightedColours.AddList(metadataAnalysis.GetColours(), MetadataWeighting);
			GetAudioAspect();
			var aggregatedColour = ColorHandling.Aggregate(_weightedColours);
			return ColorHandling.ExaggerateColour(3, aggregatedColour);
		}

		private void GetAudioAspect()
		{
			GetGenderAspect(GenderWeighting);
			GetDanceabilityAspect(DanceabilityWeighting);
			GetAcousticityAspect(AcousticityWeighting);
			GetAggressiveAspect(AggressiveWeighting);
			GetElectronicAspect(ElectronicWeighting);
			GetHappyAspect(HappyWeighting);
			GetPartyAspect(PartyWeighting);
			GetRelaxedAspect(RelaxedWeighting);
			GetSadAspect(SadWeighting);
		}

		private void GetDanceabilityAspect(int weight)
		{
			var danceability = _analysis.highlevel.danceability.probability;
			AddColour(Color.Red, Color.CornflowerBlue, danceability, weight);
		}

		private void GetGenderAspect(int weight)
		{
			var gender = _analysis.highlevel.gender.probability;
			AddColour(Color.Purple, Color.Green, gender, weight);
		}

		private void GetAcousticityAspect(int weight)
		{
			var acousticity = _analysis.highlevel.mood_acoustic.probability;
			AddColour(Color.Orange, acousticity, weight);
		}

		private void GetAggressiveAspect(int weight)
		{
			var aggressiveness = _analysis.highlevel.mood_aggressive.probability;
			AddColour(Color.Black, Color.White, aggressiveness, weight);
		}

		private void GetElectronicAspect(int weight)
		{
			var electronicness = _analysis.highlevel.mood_electronic.probability;
			AddColour(Color.Yellow, electronicness, weight);
		}

		private void GetHappyAspect(int weight)
		{
			var happiness = _analysis.highlevel.mood_happy.probability;
			AddColour(Color.DeepSkyBlue, happiness, weight);
		}

		private void GetPartyAspect(int weight)
		{
			var partyness = _analysis.highlevel.mood_party.probability;
			AddColour(Color.DeepPink, Color.Turquoise, partyness, weight);
		}

		private void GetRelaxedAspect(int weight)
		{
			var relaxedness = _analysis.highlevel.mood_relaxed.probability;
			AddColour(Color.GreenYellow, Color.Violet, relaxedness, weight);
		}

		private void GetSadAspect(int weight)
		{
			var sadness = _analysis.highlevel.mood_sad.probability;
			AddColour(Color.MidnightBlue, Color.DodgerBlue, sadness, weight);
		}

		private void AddColour(Color colour, Color antiColour, double strength, int totalWeight)
		{
			if (strength > 0.5)
			{
				var colourWeight = strength * totalWeight;
				_weightedColours.Add(new WeightedColour(colour, colourWeight));
			}
			else
			{
				var colourWeight = (1 - strength) * totalWeight;
				_weightedColours.Add(new WeightedColour(antiColour, colourWeight));
			}
		}

		private void AddColour(Color colour, double strength, int totalWeight)
		{
			if (strength > 0.5)
			{
				var colourWeight = strength * totalWeight;
				_weightedColours.Add(new WeightedColour(colour, colourWeight));
			}
		}
	}
}