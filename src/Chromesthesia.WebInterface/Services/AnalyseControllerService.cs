using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class AnalyseControllerService
	{
		private readonly dynamic _parameters;

		public AnalyseControllerService(dynamic parameters)
		{
			_parameters = parameters;
		}

		public AnalyseModel GetAnalyseModel()
		{
			var highLevel = new AcousticbrainzService().GetHighLevel(_parameters.id);
			return new AnalyseModel
				{
					HighLevel = highLevel
				};
		}
	}
}