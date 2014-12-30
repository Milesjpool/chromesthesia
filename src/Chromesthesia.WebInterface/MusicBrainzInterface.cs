using System;

namespace Chromesthesia.WebInterface
{
    public static class MusicBrainzInterface
    {
        public static string GetHighLevelAnalysisOfMbid(Guid mbid)
        {
            var httpHandler = new HttpHandler();
            var acousticBrainzResponse = httpHandler.Get(new Uri("http://acousticbrainz.org/" + mbid + "/high-level"));
            var body = httpHandler.ReadBody(acousticBrainzResponse);
            return body;
        }

    }
}