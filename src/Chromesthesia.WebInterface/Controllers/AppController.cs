using System.Web.Script.Serialization;
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

		public dynamic Chrometise(dynamic parameters, bool newChrometiser)
		{
			var controllerService = new ChrometiseControllerService(parameters, newChrometiser);
			var model = controllerService.GetChrometiseModel();
			return _routes.View["Views/Chrometise.cshtml", model];
		}

		public dynamic Hexercise(dynamic parameters)
		{
			var controllerService = new HexerciseControllerService(parameters);
			var model = controllerService.GetHexerciseModel();
			return new JavaScriptSerializer().Serialize(model);
		}

		public dynamic Analyse(dynamic parameters)
		{
			var controllerService = new AnalyseControllerService(parameters);
			var model = controllerService.GetAnalyseModel();
			return model.Analysis;
		}

		public dynamic Survey()
		{
			return _routes.View["Views/Survey.cshtml"];
		}
	}
}