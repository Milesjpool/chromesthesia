using System;
using System.IO;
using System.Net;
using NUnit.Framework;
using Nancy;

namespace Chromesthesia.WebApp
{
    public class Routes : NancyModule
    {
        public Routes()
        {
            Get["/"] = _ => RenderHomepage();
            Get["/chrometise/mbid/{id}"] = parameters => 
                "<svg xmlns='http://www.w3.org/2000/svg'>" +
                   "<rect x='5' y='5' width='180' height='90' stroke='black' fill='#22BB88'/>" +
                "</svg><p/>" +
                GetLengthOf(parameters.id);
        }

        private static string GetLengthOf(string id)
        {
            var acousticBrainzResponse = GetResponse(new Uri("http://acousticbrainz.org/" + id + "/high-level"));
            var body = ReadBodyOf(acousticBrainzResponse);
            return body;
        }

        private static HttpWebResponse GetResponse(Uri url)
        {
            var request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            var response = (HttpWebResponse)request.GetResponse();
            return response;
        }

        private static string ReadBodyOf(HttpWebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            {
                Assert.IsNotNull(responseStream, "Response stream");
                using (var streamReader = new StreamReader(responseStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        private static string RenderHomepage()
        {
            return "Welcome to Chromesthesia!";
        }
    }
}