using System;
using System.Web;

namespace Chromesthesia.WebInterface.Pages
{
    public class ChrometisePage : IWebPage<string>
    {
        private Guid _mbid;
        private bool _validMbid;

        public ChrometisePage(dynamic parameters)
        {
            _validMbid = Guid.TryParse(parameters.id, out _mbid);            
        }

        public string Render()
        {
            var hexCode = "#33B5E5";
            return "<svg xmlns='http://www.w3.org/2000/svg'>"
                   + string.Format("<rect x='5' y='5' width='180' height='90' stroke='black' fill='{0}'/>",
                                   hexCode) + "</svg><p/>";
        }
    }
}