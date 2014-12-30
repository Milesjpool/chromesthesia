using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
    public static class Browser
    {
        public static HttpWebResponse Get(Uri url)
        {
            var request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            var response = (HttpWebResponse) request.GetResponse();
            return response;
        }

        public static string ReadBodyOf(HttpWebResponse response)
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

        public static void Log(HttpWebResponse response, string body = null)
        {
            Console.WriteLine("===============");
            Console.WriteLine("{0} has status code: {1}\n", response.ResponseUri, response.StatusCode);

            Console.WriteLine("---- Head ----");
            Console.WriteLine(response.Headers);
            if (body != null)
            {
                Console.WriteLine("---- Body ----");
                Console.WriteLine(body);
            }
            Console.WriteLine("===============");
        }
    }
}