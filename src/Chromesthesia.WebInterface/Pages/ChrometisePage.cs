namespace Chromesthesia.WebInterface.Pages
{
    public class ChrometisePage : IWebPage
    {
        private dynamic _mbid;

        public ChrometisePage(dynamic parameters)
        {
            _mbid = parameters.id;            
        }

        public string Render()
        {
            var hexCode = "#33B5E5";
            return "<svg xmlns='http://www.w3.org/2000/svg'>" +
                   string.Format("<rect x='5' y='5' width='180' height='90' stroke='black' fill='{0}'/>", hexCode) +
                   "</svg><p/>";
        }
    }
}