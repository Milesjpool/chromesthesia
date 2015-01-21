using System;

namespace Chromesthesia.WebInterface.Views
{
	public class ChrometisePage : IWebPage<string>
	{
		private readonly dynamic _parameters;
		private Guid _mbid;
		private string _hexCode = "#33B5E5";

		public ChrometisePage(dynamic parameters)
		{
			_parameters = parameters;

		}

		public string Render()
		{
			if (!Guid.TryParse(_parameters.id, out _mbid))
			{
				throw new InvalidMbidException();
			}
			return "<svg xmlns='http://www.w3.org/2000/svg'>"
						 + string.Format("<rect x='5' y='5' width='180' height='90' stroke='black' fill='{0}'/>",
														 _hexCode) + "</svg><p/>";
		}
	}
}