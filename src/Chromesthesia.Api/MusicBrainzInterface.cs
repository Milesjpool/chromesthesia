using System;

namespace Chromesthesia.Api
{
    public static class MusicBrainzInterface
    {
        public static string GetHighLevelAnalysisOfMbid(string mbid)
        {
            var httpHandler = new HttpHandler();
            var acousticBrainzResponse = httpHandler.Get(new Uri("http://acousticbrainz.org/" + mbid + "/high-level"));
            var body = httpHandler.ReadBody(acousticBrainzResponse);
            return body;
        }

    }
}