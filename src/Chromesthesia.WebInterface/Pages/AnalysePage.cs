namespace Chromesthesia.WebInterface.Pages
{
    public class AnalysePage : IWebPage
    {
        private readonly dynamic _mbid;

        public AnalysePage(dynamic parameters)
        {
            _mbid = parameters.id;
        }

        public string Render()
        {
            return MusicBrainzInterface.GetHighLevelAnalysisOfMbid(_mbid);
        }
    }
}