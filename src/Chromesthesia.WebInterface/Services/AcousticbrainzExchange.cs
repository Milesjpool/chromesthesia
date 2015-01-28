using System;
using System.Net;
using Chromesthesia.WebInterface.Exceptions;
using Chromesthesia.WebInterface.HttpHelpers;
using Chromesthesia.WebInterface.Interfaces;
using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.Services
{
	public class AcousticbrainzExchange : IAcousticbrainzExchange
	{
		private readonly Uri _acousticbrainzUrl;

		public AcousticbrainzExchange()
		{
			_acousticbrainzUrl = new Uri(Properties.Settings.Default.AcousticbrainzRoot);
		}

		public string GetStatus()
		{
			return WebRequest.Create(_acousticbrainzUrl).GetHeader().StatusString();
		}

		public string GetAnalysis(Mbid mbid, string level)
		{
			try
			{
				return Analysis(mbid, level);
			}
			catch (WebException e)
			{
				if (e.Response.StatusCode().Equals(HttpStatusCode.NotFound))
				return string.Format("'{0}' is not an existing Musicbrainz ID.", mbid);
				throw;
			}
		}

		private string Analysis(Mbid mbid, string level)
		{
			var highLevelUrl = new Uri(_acousticbrainzUrl, mbid + level);
			return WebRequest.Create(highLevelUrl).GetResponse().Body();
		}
	}
}