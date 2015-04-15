using System.Drawing;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;
using Chromesthesia.WebInterface.Models;
using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.Services
{
	public class HexerciseControllerService
	{
		private readonly Mbid _mbid;
		private readonly Analysis _analysis;
		private readonly PredominantPropertyColourCalculator _colourCalculator;
		private Color _trackColour;

		public HexerciseControllerService(dynamic parameters)
		{
			var inputParser = new InputParser(parameters);
			_mbid = inputParser.GetMbid();
			_analysis = GetAcousticbrainzAnalysis();
			_colourCalculator = new PredominantPropertyColourCalculator();
			_trackColour = _colourCalculator.From(_analysis);
		}

		public HexerciseModel GetHexerciseModel()
		{
			return new HexerciseModel
				{
					Artist = _analysis.metadata.tags.artist[0],
					Track = _analysis.metadata.tags.title[0],
					MusicbrainzId = _mbid.ToString(),
					HtmlColour = HtmlColour(),
					RgbColour = TrackColour()
				};
		}

		private string TrackColour()
		{
			return "RGB(" + _trackColour.R + ", " + _trackColour.G + ", " + _trackColour.B + ")";
		}

		private string HtmlColour()
		{
			return ToHex(_trackColour);
		}

		private Analysis GetAcousticbrainzAnalysis()
		{
			return new AcousticbrainzExchange().GetAnalysisOf(_mbid).Deserialize();
		}

		private static string ToHex(Color color)
		{
			return "#" + color.R.ToString("X2") +
									 color.G.ToString("X2") +
									 color.B.ToString("X2");
		}
	}
}