using System.Collections.Generic;
using Chromesthesia.WebInterface.Models;
using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.Services
{
	public class HomeControllerService
	{
		public HomeModel GetHomeModel()
		{
			return new HomeModel
				{
					Tracks = Tracks(),
				};
		}

		private List<Track> Tracks()
		{
			var id1 = new SevenDigitalId("21849720");
			var id2 = new SevenDigitalId("5971578");
			return new List<Track>
				{
					new Track {Id7D = id1, Mbid = id1.ToMbid()},
					new Track {Id7D = id2, Mbid = id2.ToMbid()},
				};
		}
	}
}