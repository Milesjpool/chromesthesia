using System.Drawing;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;
using Chromesthesia.WebInterface.Chrometisation;
using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class ChrometiseControllerService
	{
		private readonly InputParser _inputParser;
		private Analysis _analysis;

		public ChrometiseControllerService(dynamic parameters)
		{
			_inputParser = new InputParser(parameters);
			_analysis = GetAcousticbrainzAnalysis();
		}

		public ChrometiseModel GetChrometiseModel()
		{
			return new ChrometiseModel
				{
					Artist = _analysis.metadata.tags.artist[0],
					Track = _analysis.metadata.tags.title[0],
					HtmlColour = HtmlColour()
				};
		}

		private string HtmlColour()
		{
			return ToHex(TrackColour());
		}

		private Color TrackColour()
		{
			return new ColourCalculator().From(_analysis);
		}

		private Analysis GetAcousticbrainzAnalysis()
		{
			var mbid = _inputParser.GetMbid();
			return new AcousticbrainzExchange().GetAnalysisOf(mbid).Deserialize();
		}

		private static string ToHex(Color color)
		{
			return "#" + color.R.ToString("X2") +
									 color.G.ToString("X2") +
									 color.B.ToString("X2");
		}
	}
}