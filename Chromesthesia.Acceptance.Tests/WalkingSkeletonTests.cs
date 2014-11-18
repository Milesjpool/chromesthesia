using System;
using System.Net;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
    [TestFixture]
    public class WalkingSkeletonTests
    {
        [Test]
        public void Test_number_1984()
        {
            Assert.That(2 + 2, Is.Not.EqualTo(5));
        }

        [Ignore]
        [Test]
        public void Gets_okay_status_from_webserver()
        {
            var rootUrl = new Uri("");
            var request = WebRequest.Create(rootUrl);
            var response = (HttpWebResponse) request.GetResponse();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}