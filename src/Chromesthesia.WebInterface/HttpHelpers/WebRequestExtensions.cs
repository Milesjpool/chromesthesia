using System.Net;

namespace Chromesthesia.WebInterface.HttpHelpers
{
	public static class WebRequestExtensions
	{
		public static WebResponse GetHeader(this WebRequest request)
		{
			//request.Method = WebRequestMethods.Http.Head;
			return request.GetResponse();
		}
	}
}