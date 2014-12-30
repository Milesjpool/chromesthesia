using System;
using System.Reflection;
using System.Text;

namespace Chromesthesia.WebInterface.Pages
{
    public class StatusPage : IWebPage
    {
        private readonly Uri _rootUrl;
        private readonly Uri _abUrl;

        public StatusPage()
        {
            _rootUrl = new Uri("http://localhost:50249/");
            _abUrl = new Uri("http://acousticbrainz.org/");
        }

        public string Render()
        {
            var pageHtml = new StringBuilder("<h1>Chromesthesia</h1>");
            pageHtml.AppendFormat("Server Time: {0} <p/>", DateTime.Now);
            pageHtml.AppendFormat("Version: {0} <p/>", AssemblyVersion());
            pageHtml.AppendFormat("Chromesthesia Status: {0} <p/>", StatusOf(_rootUrl));
            pageHtml.AppendFormat("Acousticbrainz Status: {0} <p/>", StatusOf(_abUrl));
            return pageHtml.ToString();
        }

        private string StatusOf(Uri url)
        {
            return new HttpHandler().StatusString(url);
        }

        private string AssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}