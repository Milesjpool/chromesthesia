using System;
using System.Net;
using Chromesthesia.WebInterface.Exceptions;
using Chromesthesia.WebInterface.HttpHelpers;
using Chromesthesia.WebInterface.Interfaces;
using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.AcousticbrainzHelpers
{
	public class AcousticbrainzExchange : IAcousticbrainzExchange
	{
		private readonly Uri _acousticbrainzUrl;

		public AcousticbrainzExchange()
		{
			_acousticbrainzUrl = new Uri(Properties.Settings.Default.AcousticbrainzRoot);
		}

		public AcousticbrainzResult GetAnalysisOf(Mbid mbid)
		{
			var highLevelJson = Analysis(mbid, "/high-level");
			var lowLevelJson = Analysis(mbid, "/low-level");

			return new AcousticbrainzResult
				{
					HighLevelJson = highLevelJson,
					LowLevelJson = lowLevelJson,
				};
		}

		private string Analysis(Mbid mbid, string level)
		{
			var url = new Uri(_acousticbrainzUrl, mbid + level);
			try
			{
				return WebRequest.Create(url).GetResponse().Body();
			}
			catch (WebException e)
			{
				var status = e.Response.StatusCode();
				if (status.Equals(HttpStatusCode.NotFound)) throw new NoDataForTrackException(mbid);
				throw;
			}
		}

		public string GetStatus()
		{
			return WebRequest.Create(_acousticbrainzUrl).GetHeader().StatusString();
		}
	}
}