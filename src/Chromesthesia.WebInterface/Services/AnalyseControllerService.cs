using Chromesthesia.WebInterface.AcousticbrainzHelpers;
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
					Analysis = Analysis()
				};
		}

		private string Analysis()
		{
			try
			{
				var mbid = _inputParser.GetMbid();
				return new AcousticbrainzExchange().GetAnalysisOf(mbid).HighLevelJson;
			}
			catch (InvalidMusicbrainzIdException e)
			{
				return string.Format("'{0}' is not a valid Musicbrainz ID", e.Mbid);
			}
		}
	}
}