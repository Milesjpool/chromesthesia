using System;
using System.Net;
using Chromesthesia.WebInterface.HttpHelpers;
using Chromesthesia.WebInterface.Interfaces;
using Chromesthesia.WebInterface.Parsing;
using Nancy.Json;

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
			return WebRequest.Create(url).GetResponse().Body();
		}

		public string GetStatus()
		{
			return WebRequest.Create(_acousticbrainzUrl).GetHeader().StatusString();
		}
	}
}