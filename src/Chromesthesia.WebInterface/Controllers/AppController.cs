using Chromesthesia.WebInterface.Services;

namespace Chromesthesia.WebInterface.Controllers
{
	public class AppController
	{
		private readonly Routes _routes;

		public AppController(Routes routes)
		{
			_routes = routes;
		}

		public dynamic Home()
		{
			var controllerService = new HomeControllerService();
			var model = controllerService.GetHomeModel();
			return _routes.View["Views/Home.cshtml", model];
		}

		public dynamic Status()
		{
			var controllerService = new StatusControllerService();
			var model = controllerService.GetStatusModel();
			return _routes.View["Views/Status.cshtml", model];
		}

		public dynamic Chrometise(dynamic parameters)
		{
			var controllerService = new ChrometiseControllerService(parameters);
			var model = controllerService.GetChrometiseModel();
			return _routes.View["Views/Chrometise.cshtml", model];
		}

		public dynamic Analyse(dynamic parameters)
		{
			var controllerService = new AnalyseControllerService(parameters);
			var model = controllerService.GetAnalyseModel();
			return model.Analysis;
		}

		public dynamic Survey()
		{
			var controllerService = new SurveyControllerService();
			var model = controllerService.GetSurveyModel();
			return _routes.View["Views/Survey.cshtml", model];
		}
	}
}