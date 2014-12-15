using System;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
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
            GetPageResponse(new Uri(_rootUrl));
        }

        public void NavigateToStatusPage()
        {
            GetPageResponse(new Uri(_rootUrl + "status"));
        }

        public void NavigateToChrometiseMbid(string mbid)
        {
            GetPageResponse(new Uri(_rootUrl + "chrometise/mbid/" + mbid));
        }

        public void NavigateToAnalyseMbid(string mbid)
        {
            GetPageResponse(new Uri(_rootUrl + "analyse/mbid/" + mbid));
        }

        private void GetPageResponse(Uri url)
        {
            _response = Browser.Get(url);
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

        public void CheckResponseMatchesRegex(string regexPattern)
        {
            Console.WriteLine("Regex pattern to match: " + regexPattern);
            Assert.True(Regex.IsMatch(_body, regexPattern));
        }
    }
}