using Chromesthesia.WebInterface.Controllers;
using Nancy;

namespace Chromesthesia.WebInterface
{
	public class Routes : NancyModule
	{
		public Routes()
		{
			var controller = new AppController(this);
			Get["/"] = _ => controller.Home();
			Get["/status"] = _ => controller.Status();
			Get["/analyse/mbid/{id}"] = parameters => controller.Analyse(parameters);
			Get["/chrometise/mbid/{id}"] = parameters => controller.Chrometise(parameters);
			Get["/survey"] = _ => controller.Survey();
		}
	}
}