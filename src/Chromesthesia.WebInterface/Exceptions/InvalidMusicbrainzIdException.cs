using System;

namespace Chromesthesia.WebInterface.Exceptions
{
	public class InvalidMusicbrainzIdException : Exception
	{
		public string Mbid { get; private set; }

		public InvalidMusicbrainzIdException(string id)
		{
			Mbid = id;
		}
	}
}