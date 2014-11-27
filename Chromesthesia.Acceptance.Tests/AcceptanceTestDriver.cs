using System;
using System.Net;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
    public class AcceptanceTestDriver
    {
        private HttpWebResponse _response;
        private string _body;

        public void NavigateToRoot()
        {
             var rootUrl = new Uri("http://localhost:50249/");

            _response = Browser.Get(rootUrl);
            _body = Browser.ReadBodyOf(_response);
            Browser.Log(_response, _body);
        }

        public void NavigateToChrometiseMbid(string mbid)
        {
            var mbidUrl = new Uri("http://localhost:50249/chrometise/mbid/" + mbid);

            _response = Browser.Get(mbidUrl);
            _body = Browser.ReadBodyOf(_response);
            Browser.Log(_response, _body);
        }

        public void CheckWebpageIsOkay()
        {
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void CheckResponseContains(string expectedString)
        {
            Assert.That(_body, Is.StringContaining(expectedString));
        }
    }
}