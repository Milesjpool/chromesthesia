using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class HomeControllerService
	{
		public HomeModel GetHomeModel()
		{
			return new HomeModel
				{
					mbid = Mbid(),
				};
		}

		private static string Mbid()
		{
			return "f989fa05-7e2b-4e88-8a95-b5d68480b539";
		}
	}
}