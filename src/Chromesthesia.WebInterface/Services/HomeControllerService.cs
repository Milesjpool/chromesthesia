using System.Collections.Generic;
using Chromesthesia.WebInterface.Models;
using SevenDigital.Api.Schema.Tracks;
using SevenDigital.Api.Wrapper;

namespace Chromesthesia.WebInterface.Services
{
	public class HomeControllerService
	{
		public HomeModel GetHomeModel()
		{
			return new HomeModel
				{
					ExampleTracks = ExampleTracks(),
					SearchResults = SearchResults()
				};
		}

		private List<TrackSearchResult> SearchResults()
		{
			return new List<TrackSearchResult>();
		}

		private List<ExampleTrack> ExampleTracks()
		{
			return new List<ExampleTrack>
				{
					new ExampleTrack("21849720"),
					new ExampleTrack("5971578"),
					new ExampleTrack("1181138"),
					new ExampleTrack("487885"),
					new ExampleTrack("20505133"),
					new ExampleTrack("1187217"),
					new ExampleTrack("12345"),
					new ExampleTrack("1231"),
				};
		}
	}
}