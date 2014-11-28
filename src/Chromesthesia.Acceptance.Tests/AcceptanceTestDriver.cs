using System;
using System.Configuration;
using System.Net;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
    public class AcceptanceTestDriver
    {
        private HttpWebResponse _response;
        private string _body;
        private readonly string _rootUrl = ConfigurationManager.AppSettings["RootUrl"];

        public void NavigateToRoot()
        {
            _response = Browser.Get(new Uri(_rootUrl));
            _body = Browser.ReadBodyOf(_response);
            Browser.Log(_response, _body);
        }

        public void NavigateToChrometiseMbid(string mbid)
        {
            var mbidUrl = new Uri(_rootUrl + "chrometise/mbid/" + mbid);

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