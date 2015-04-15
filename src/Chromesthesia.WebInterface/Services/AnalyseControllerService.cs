using Chromesthesia.WebInterface.AcousticbrainzHelpers;
using Chromesthesia.WebInterface.Exceptions;
using Chromesthesia.WebInterface.Models;
using Chromesthesia.WebInterface.Parsing;

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
			var mbid = _inputParser.GetMbid();
			return new AcousticbrainzExchange().GetAnalysisOf(mbid).HighLevelJson;
		}
	}
}