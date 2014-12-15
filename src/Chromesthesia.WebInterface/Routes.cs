﻿using Nancy;

namespace Chromesthesia.WebInterface
{
    public class Routes : NancyModule
    {
        public Routes()
        {
            var renderer = new PageRenderer();
            Get["/"] = _ => renderer.RenderHomepage();
            Get["/status"] = _ => renderer.RenderStatusPage();
            Get["/analyse/mbid/{id}"] = parameters => renderer.RenderAnalyseMbidPage(parameters);
            Get["/chrometise/mbid/{id}"] = parameters => renderer.RenderChrometiseMbidPage(parameters);
        }
    }
}