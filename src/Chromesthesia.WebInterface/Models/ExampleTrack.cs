using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.Models
{
	public class ExampleTrack
	{
		public ExampleTrack(string id)
		{
			Id7D = new SevenDigitalId(id);
		}

		public SevenDigitalId Id7D { get; set; }
	}
}