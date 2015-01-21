using System;

namespace Chromesthesia.WebInterface.Views
{
	public class AnalysePage : IWebPage<string>
	{
		private readonly dynamic _parameters;
		private Guid _mbid;

		public AnalysePage(dynamic parameters)
		{
			_parameters = parameters;
		}

		public string Render()
		{
			try
			{
				return GetAnalysisOfMbid(_parameters.id);
			}
			catch (InvalidMbidException)
			{
				return string.Format("'{0}' is not a valid Musicbrainz ID.", _parameters.id);
			}
		}

		private string GetAnalysisOfMbid(string inputId)
		{
			if (!Guid.TryParse(inputId, out _mbid))
			{
				throw new InvalidMbidException();
			}
			return Acousticbrainz.HighLevelAnalysis(_mbid);
		}
	}
}