
namespace Chromesthesia.WebInterface
{
    public class PageRenderer
    {
        public string RenderHomepage()
        {
            return "Welcome to Chromesthesia!";
        }

        public string RenderChrometiseMbidPage(dynamic parameters)
        {
            var mbid = parameters.id;
            var trackAnalysis = MusicBrainzInterface.GetHighLevelAnalysisOfMbid(mbid);
            var hexCode = "#22BB88";
            return "<svg xmlns='http://www.w3.org/2000/svg'>" +
                   string.Format("<rect x='5' y='5' width='180' height='90' stroke='black' fill='{0}'/>", hexCode) +
                   "</svg><p/>" + trackAnalysis;
        }
    }
}