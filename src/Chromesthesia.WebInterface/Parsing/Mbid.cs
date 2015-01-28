using System;
using Chromesthesia.WebInterface.Exceptions;

namespace Chromesthesia.WebInterface.Parsing
{
	public class Mbid
	{
		private readonly Guid _mbid;

		public Mbid(dynamic id)
		{
			if (!Guid.TryParse(id, out _mbid))
			{
				throw new InvalidMusicbrainzIdException(id);
			}
		}

		public override string ToString()
		{
			return _mbid.ToString().ToLower();
		}
	}
}