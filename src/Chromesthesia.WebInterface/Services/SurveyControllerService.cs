using System.Collections.Generic;
using System.Web.Mvc;

namespace Chromesthesia.WebInterface.Services
{
	public class SurveyControllerService : Controller
	{
		readonly IDictionary<int, string> _tracks;
		private int _currentTrack;

		public SurveyControllerService()
		{
			_currentTrack = 0;
			_tracks = SurveyTracks.GetDictionaryOfPaths();
		}

	public SurveyModel GetSurveyModel()
		{
			return new SurveyModel
				{
					trackPath = TrackPath(),
				};
		}

		private string TrackPath()
		{
			var trackPath = _tracks[_currentTrack];
			return trackPath;
		}
	}
}