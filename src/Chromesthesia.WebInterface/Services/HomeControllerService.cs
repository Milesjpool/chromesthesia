using System.Web.Mvc;
using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Controllers
{
	public class HomeControllerService
	{
		public HomeModel GetHomeModel()
		{
			return new HomeModel();
		}
	}
}