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
            _response = Browser.Get(new Uri(_rootUrl));
            _body = Browser.ReadBodyOf(_response);
            Browser.Log(_response, _body);
        }

        public void NavigateToChrometiseMbid(string mbid)
        {
            GetMbidAnalysisResult("chrometise", mbid);
        }

        public void NavigateToAnalyseMbid(string mbid)
        {
            GetMbidAnalysisResult("analyse", mbid);
        }

        private void GetMbidAnalysisResult(string resultType, string mbid)
        {
            var url = new Uri(_rootUrl + resultType + "/mbid/" + mbid);

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

        public void CheckResponseContainsHexCode()
        {
            string hexPattern = "\'#[A-Fa-f0-9]{6}\'";
            Assert.True(Regex.IsMatch(_body, hexPattern));
        }
    }
}