using System.Collections.Generic;
using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class HomeControllerService
	{
		public HomeModel GetHomeModel()
		{
			return new HomeModel
				{
					Ids7D = Ids7D(),
					Mbids = Mbids(),
				};
		}

		private List<string> Ids7D()
		{
			return new List<string>
				{
					"21849720",
					"5971578"
				};
		}

		private List<string> Mbids()
		{
			return new List<string>
				{
					"c9017c7b-0d67-4cac-8626-35e4b73e5285",
					"5f64bf87-a18e-4ac0-8a49-dc1d500a8ba5"
				};
		}
	}
}