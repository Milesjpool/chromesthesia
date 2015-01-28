using System;
using System.Net;
using Chromesthesia.WebInterface.Exceptions;
using Chromesthesia.WebInterface.HttpHelpers;

namespace Chromesthesia.WebInterface.Parsing
{
	public class SevenDigitalId
	{
		readonly string _id;

		public SevenDigitalId(dynamic id)
		{
			_id = id.ToString();
		}

		public override string ToString()
		{
			return _id;
		}

		public Mbid ToMbid()
		{
			string response;
			try
			{
				var url = ConversionUrl();
				response = WebRequest.Create(url).GetResponse().Body();
			}
			catch (WebException e)
			{
				var status = e.Response.StatusCode();
				if (status.Equals(HttpStatusCode.BadRequest))
					throw new Invalid7DigitalIdException();
				if (status.Equals(HttpStatusCode.NotFound))
					throw new MusicbrainzIdNotFoundException();
				throw;
			}

			return new Mbid(response);
		}

		private Uri ConversionUrl()
		{
			var toMbidUrl = Properties.Settings.Default.ToMusicbrainzUrl;
			return new Uri(string.Format(toMbidUrl, _id));
		}
	}
}