using System;
using System.IO;
using System.Net;

namespace SurveyResults
{
	public static class ParseApi
	{
		private const string RootUrl = @"https://api.parse.com/1/classes/Opinion";

		public static string GetDataFor(int trackId)
		{
			var requestUri = new Uri(RootUrl + "?where%3D%7B%22TrackId%22%3A" + trackId + "%7D");
			var response = GetResponse(requestUri);
			return ReadBodyOf(response);
		}
		
		private static HttpWebResponse GetResponse(Uri url)
		{
			var request = WebRequest.Create(url);
			request.Method = WebRequestMethods.Http.Get;
			request.Headers.Add("X-Parse-Application-Id", "LSqmQRHWpRXDusXRfFAPILmeMHBLabJ6KU7LeqJg");
			request.Headers.Add("X-Parse-REST-API-Key", "D8AyMMrsNCOALIUUAqkiiw0N0leYgs6l2AkDt8iP");
			return (HttpWebResponse) request.GetResponse();
		}

		private static string ReadBodyOf(HttpWebResponse response)
		{
			using (var responseStream = response.GetResponseStream())
			{
				using (var streamReader = new StreamReader(responseStream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}
	}
}