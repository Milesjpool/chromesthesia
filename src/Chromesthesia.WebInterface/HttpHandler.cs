using System;
using System.IO;
using System.Net;

namespace Chromesthesia.WebInterface
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

        private HttpStatusCode GetStatus(Uri url)
        {
            var request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Head;
            var response = (HttpWebResponse)request.GetResponse();
            return response.StatusCode;
        }

        public string StatusString(Uri url)
        {
            var status = GetStatus(url);
            return string.Format("{0} ({1})", (int) status, status);
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