using Chromesthesia.WebInterface.Views;
using Nancy;

namespace Chromesthesia.WebInterface
{
    public class Routes : NancyModule
    {
        public Routes()
        {
            Get["/"] = _ => new Homepage().Render();
            Get["/status"] = _ => new StatusPage().Render();
            Get["/analyse/mbid/{id}"] = parameters => new AnalysePage(parameters).Render();
            Get["/chrometise/mbid/{id}"] = parameters => new ChrometisePage(parameters).Render();
            Get["/survey"] = _ => new SurveyPage(this).Render();
        }
    }

}