using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class HomeControllerService
	{
		public HomeModel GetHomeModel()
		{
			return new HomeModel
				{
					Mbid = Mbid(),
				};
		}

		private static string Mbid()
		{
			return "0310e92c-331c-4f61-bc4d-3c3ba6e88aec";
		}
	}
}