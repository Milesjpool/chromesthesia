using System;
using System.Text;

namespace Chromesthesia.WebInterface.Views
{
    public class StatusPage : IWebPage<string>
    {
        public string Render()
        {
            var pageHtml = new StringBuilder("<h1>Chromesthesia</h1>");
            pageHtml.AppendFormat("Server Time: {0} <p/>", DateTime.Now);
            pageHtml.AppendFormat("Version: {0} <p/>", ChromesthesiaApp.AssemblyVersion);
            pageHtml.AppendFormat("Machine Name: {0} <p/>", Environment.MachineName);
            pageHtml.AppendFormat("Acousticbrainz Status: {0} <p/>", Acousticbrainz.Status);
            return pageHtml.ToString();
        }
    }
}