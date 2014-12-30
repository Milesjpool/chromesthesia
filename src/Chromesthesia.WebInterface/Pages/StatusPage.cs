using System;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace Chromesthesia.WebInterface.Pages
{
    public class StatusPage : IWebPage
    {

        public string Render()
        {
            var pageHtml = new StringBuilder("<h1>Chromesthesia</h1>");
            pageHtml.AppendFormat("Server Time: {0} <p/>", DateTime.Now);
            pageHtml.AppendFormat("Version: {0} <p/>", AssemblyVersion());
            pageHtml.AppendFormat("Machine Name: {0} <p/>", MachineName());
            pageHtml.AppendFormat("Acousticbrainz Status: {0} <p/>", AcousticbrainzStatus());
            return pageHtml.ToString();
        }

        private string MachineName()
        {
            return Environment.MachineName;
        }

        private string AcousticbrainzStatus()
        {
            var abUrl = new Uri(ConfigurationManager.ConnectionStrings["AcousticbrainzUrl"].ConnectionString);
            return new HttpHandler().StatusString(abUrl);
        }

        private string AssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}