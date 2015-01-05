using System;
using System.Configuration;

namespace Chromesthesia.WebInterface
{
    public static class Acousticbrainz
    {
        public static string Status
        {
            get
            {
                var abUrl = new Uri(ConfigurationManager.ConnectionStrings["AcousticbrainzUrl"].ConnectionString);
                return new HttpHandler().StatusString(abUrl);
            }
        }

        public static string HighLevelAnalysis(Guid mbid)
        {
            var httpHandler = new HttpHandler();
            var acousticBrainzResponse = httpHandler.Get(new Uri("http://acousticbrainz.org/" + mbid + "/high-level"));
            var body = httpHandler.ReadBody(acousticBrainzResponse);
            return body;
        }
    }
}