using System;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using Chromesthesia.Test.Helpers;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
	public class AcceptanceTestDriver
	{
		private HttpWebResponse _response;
		private string _body;
		private readonly string _rootUrl;

		public AcceptanceTestDriver()
		{
			_rootUrl = ConfigurationManager.AppSettings["RootUrl"];
		}

		public void NavigateToRoot()
		{
			GetPageResponse(new Uri(_rootUrl));
		}

		public void NavigateToStatusPage()
		{
			GetPageResponse(new Uri(_rootUrl + "status"));
		}

		public void NavigateToAnalyse(string idType, string trackId)
		{
			GetPageResponse(new Uri(_rootUrl + "analyse/" + idType + "/" + trackId));
		}

		public void NavigateToChrometise(string idType, string trackId)
		{
			GetPageResponse(new Uri(_rootUrl + "chrometise/" + idType + "/" + trackId));
		}

		public void NavigateToSurveyPage()
		{
			GetPageResponse(new Uri(_rootUrl + "survey/"));
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