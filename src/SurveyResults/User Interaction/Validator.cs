using System.Collections.Generic;
using System.Configuration;

namespace SurveyResults
{
	public class Validator
	{
		private readonly int _maxId;

		public Validator(){
			_maxId = int.Parse(ConfigurationManager.AppSettings["NumTracks"]);
			
		}

		public bool IsValidTrackId(int trackId)
		{
			return (trackId >= 0) && (trackId <= _maxId);
		}

		public bool IsYes(string input)
		{
			var affirmative = new List<string> {"y", "yes", "yep", "yeah", "yup", "si", "oui", "ja"};
			return affirmative.Contains(input.ToLower());
		}
	}
}