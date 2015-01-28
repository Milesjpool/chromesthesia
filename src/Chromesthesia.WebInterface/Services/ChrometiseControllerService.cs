using System.Drawing;
using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class ChrometiseControllerService
	{
		private readonly InputParser _inputParser;


		public ChrometiseControllerService(dynamic parameters)
		{
			_inputParser = new InputParser(parameters);
		}

		public ChrometiseModel GetChrometiseModel()
		{
			return new ChrometiseModel
				{
					HtmlColour = HtmlColour()
				};
		}

		private string HtmlColour()
		{
			var trackColour = Color.FromArgb(51, 181, 229);
			return ColorTranslator.ToHtml(trackColour);
		}
	}
}