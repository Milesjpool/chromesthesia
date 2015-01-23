using System.Drawing;
using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class ChrometiseControllerService
	{
		private readonly dynamic _parameters;

		public ChrometiseControllerService(dynamic parameters)
		{
			_parameters = parameters;
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