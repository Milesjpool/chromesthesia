using System.Reflection;

namespace Chromesthesia.WebInterface.Pages
{
    public static class ChromesthesiaApp
    {
        public static string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }
    }
}