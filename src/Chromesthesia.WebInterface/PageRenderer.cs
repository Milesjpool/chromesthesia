
using System.Reflection;

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
            var hexCode = "#33B5E5";
            return "<svg xmlns='http://www.w3.org/2000/svg'>" +
                   string.Format("<rect x='5' y='5' width='180' height='90' stroke='black' fill='{0}'/>", hexCode) +
                   "</svg><p/>";
        }

        public string RenderAnalyseMbidPage(dynamic parameters)
        {
            var mbid = parameters.id;
            return MusicBrainzInterface.GetHighLevelAnalysisOfMbid(mbid);
        }


        public string RenderStatusPage()
        {
            return string.Format("<h1>Chromesthesia</h1>" +
                                 "version: {0} <p/>" +
                                 "status: 200 (OK)",
                                    GetAssemblyVersion()
                                 );
        }

        private string GetAssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}