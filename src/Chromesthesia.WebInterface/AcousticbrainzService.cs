using System;
using System.Configuration;
using Chromesthesia.WebInterface.Exceptions;

namespace Chromesthesia.WebInterface
{
	public class AcousticbrainzService
	{

		public string GetHighLevel(string mbid)
		{
			try
			{
				return GetAnalysisOfMbid(mbid);
			}
			catch (InvalidMbidException)
			{
				return string.Format("'{0}' is not a valid Musicbrainz ID.", mbid);
			}
		}

		private string GetAnalysisOfMbid(string inputId)
		{
			Guid mbid;
			if (!Guid.TryParse(inputId, out mbid))
			{
				throw new InvalidMbidException();
			}
			return HighLevelAnalysis(mbid);
		}

		private string HighLevelAnalysis(Guid mbid)
		{
			var httpHandler = new HttpHandler();
			var acousticBrainzResponse = httpHandler.Get(new Uri("http://acousticbrainz.org/" + mbid + "/high-level"));
			var body = httpHandler.ReadBody(acousticBrainzResponse);
			return body;
		}
	}
}