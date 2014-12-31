using System.Web;

namespace Chromesthesia.WebInterface.Pages
{
    public class Homepage : IWebPage<string>
    {
        public string Render()
        {
            return "<h1>Welcome to Chromesthesia!</h1>" +
                   "Chrometise MBID: " +
                   "<a href='/chrometise/mbid/f989fa05-7e2b-4e88-8a95-b5d68480b539'>" +
                   "f989fa05-7e2b-4e88-8a95-b5d68480b539" +
                   "</a>";
        }
    }
}