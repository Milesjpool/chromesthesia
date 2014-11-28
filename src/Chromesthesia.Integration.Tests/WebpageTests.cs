using System;
using System.Net;
using System.Configuration;
using NUnit.Framework;

namespace Chromesthesia.Integration.Tests
{
    [TestFixture]
    public class WebpageTests
    {
        [Test]
        public void Gets_okay_status_from_webserver()
        {
            var urlString = ConfigurationManager.AppSettings["RootUrl"];
            var rootUrl = new Uri(urlString);
            var request = WebRequest.Create(rootUrl);
            var response = (HttpWebResponse)request.GetResponse();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
