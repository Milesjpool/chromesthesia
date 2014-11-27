using System;
using System.IO;
using System.Net;

namespace Chromesthesia.WebApi
{
    public class HttpHandler
    {

        public HttpWebResponse Get(Uri url)
        {
            var request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            var response = (HttpWebResponse)request.GetResponse();
            return response;
        }

        public string ReadBody(HttpWebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null) throw new ArgumentException("No response");
                using (var streamReader = new StreamReader(responseStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}