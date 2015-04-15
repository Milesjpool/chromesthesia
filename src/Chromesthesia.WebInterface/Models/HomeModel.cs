using System.Collections.Generic;
using SevenDigital.Api.Schema.Tracks;

namespace Chromesthesia.WebInterface.Models
{
	public class HomeModel
	{
		public List<ExampleTrack> ExampleTracks { get; set; }
		public List<TrackSearchResult> SearchResults { get; set; }
	}
}