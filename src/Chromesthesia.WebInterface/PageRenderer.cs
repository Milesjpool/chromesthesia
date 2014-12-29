
using System;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace Chromesthesia.WebInterface
{
    public class PageRenderer
    {

        public string RenderHomepage()
        {
            return "<h1>Welcome to Chromesthesia!</h1>" +
                   "Chrometise MBID: " +
                   "<a href='/chrometise/mbid/f989fa05-7e2b-4e88-8a95-b5d68480b539'>" +
                        "f989fa05-7e2b-4e88-8a95-b5d68480b539" +
                   "</a>";
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
    }
}