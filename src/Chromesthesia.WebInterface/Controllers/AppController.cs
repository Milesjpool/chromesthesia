using System.Web.Script.Serialization;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;
using Chromesthesia.WebInterface.Exceptions;
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
			try
			{
				var controllerService = new ChrometiseControllerService(parameters, newChrometiser);
				var model = controllerService.GetChrometiseModel();
				return _routes.View["Views/Chrometise.cshtml", model];
			}
			catch (ChromesthesiaException e)
			{
				return e.DefaultModel;
			}
		}

		public dynamic Hexercise(dynamic parameters)
		{
			try
			{
				var controllerService = new HexerciseControllerService(parameters);
				var model = controllerService.GetHexerciseModel();
				return new JavaScriptSerializer().Serialize(model);
			}
			catch (ChromesthesiaException e)
			{
				return e.DefaultModel;
			}
		}

		public dynamic Analyse(dynamic parameters)
		{
			try
			{
				var controllerService = new AnalyseControllerService(parameters);
				var model = controllerService.GetAnalyseModel();
				return model.Analysis;
			}
			catch (ChromesthesiaException e)
			{
				return e.DefaultModel;
			}
		}

		public dynamic Survey()
		{
			return _routes.View["Views/Survey.cshtml"];
		}
	}
}