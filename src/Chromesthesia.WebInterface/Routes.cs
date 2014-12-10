using Nancy;

namespace Chromesthesia.WebInterface
{
    public class Routes : NancyModule
    {
        public Routes()
        {
            var renderer = new PageRenderer();
            Get["/"] = _ => renderer.RenderHomepage();
            Get["/chrometise/mbid/{id}"] = parameters =>
                    renderer.RenderChrometiseMbidPage(parameters);
            Get["/analyse/mbid/{id}"] = parameters =>
                    renderer.RenderAnalyseMbidPage(parameters);
            Get["/status"] = _ =>
                    renderer.RenderStatusPage();
        }
    }
}