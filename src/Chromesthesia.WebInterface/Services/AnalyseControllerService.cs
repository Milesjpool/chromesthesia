using Chromesthesia.WebInterface.Exceptions;
using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class AnalyseControllerService
	{
		private readonly InputParser _inputParser;

		public AnalyseControllerService(dynamic parameters)
		{
			_inputParser = new InputParser(parameters);
		}

		public AnalyseModel GetAnalyseModel()
		{
			return new AnalyseModel
				{
					HighLevel = HighLevel()
				};
		}

		private string HighLevel()
		{
			try
			{
				var mbid = _inputParser.GetMbid();
				return new AcousticbrainzExchange().GetAnalysis(mbid, AnalysisLevels.High);
			}
			catch (InvalidMusicbrainzIdException e)
			{
				return string.Format("'{0}' is not a valid Musicbrainz ID", e.Mbid);
			}
		}
	}
}