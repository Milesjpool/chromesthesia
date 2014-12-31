using System;

namespace Chromesthesia.WebInterface.Pages
{
    public class AnalysePage : IWebPage<string>
    {
        private readonly Guid _mbid;
        private bool _validMbid;

        public AnalysePage(dynamic parameters)
        {
            _validMbid = Guid.TryParse(parameters.id, out _mbid);
        }

        public string Render()
        {
            return MusicBrainzInterface.GetHighLevelAnalysisOfMbid(_mbid);
        }
    }
}