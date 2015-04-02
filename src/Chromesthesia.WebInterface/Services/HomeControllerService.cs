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
			var id3 = new SevenDigitalId("1181138");
			var id4 = new SevenDigitalId("487885");
			var id5 = new SevenDigitalId("20505133");
			return new List<Track>
				{
					new Track {Id7D = id1, Mbid = id1.ToMbid()},
					new Track {Id7D = id2, Mbid = id2.ToMbid()},
					new Track {Id7D = id3, Mbid = id3.ToMbid()},
					new Track {Id7D = id4, Mbid = id4.ToMbid()},
					new Track {Id7D = id5, Mbid = id5.ToMbid()},
				};
		}
	}
}