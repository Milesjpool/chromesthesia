using System;
using System.IO;
using System.Net;

namespace Chromesthesia.WebInterface.HttpHelpers
{
	public static class WebResponseExtensions
	{
		public static string StatusString(this WebResponse wr)
		{
			var hsc = wr.StatusCode();
			return string.Format("{0} ({1})", (int)hsc, hsc);
		}

		public static HttpStatusCode StatusCode(this WebResponse wr)
		{
			return ((HttpWebResponse) wr ).StatusCode;
		}

		public static string Body(this WebResponse wr)
		{
			using (var responseStream = wr.GetResponseStream())
			{
				if (responseStream == null) throw new ArgumentException("No response");
				using (var streamReader = new StreamReader(responseStream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}
	}
}