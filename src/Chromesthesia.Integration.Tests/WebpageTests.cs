using System;
using System.Net;
using NUnit.Framework;

namespace Chromesthesia.Integration.Tests
{
    [TestFixture]
    public class WebpageTests
    {
        [Test]
        public void Gets_okay_status_from_webserver()
        {
            var rootUrl = new Uri("http://localhost:50249/");
            var request = WebRequest.Create(rootUrl);
            var response = (HttpWebResponse)request.GetResponse();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
