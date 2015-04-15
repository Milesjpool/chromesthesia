namespace Chromesthesia.WebInterface.Exceptions
{
	public class InvalidMusicbrainzIdException : ChromesthesiaException
	{
		private readonly string _id;

		public InvalidMusicbrainzIdException(string id)
		{
			_id = id;
		}

		public override dynamic DefaultModel
		{
			get
			{
				return "{" +
							 "\"id\":\"" + _id + "\"," +
							 "\"error\":\"This is not a valid Musicbrainz track ID\"" +
							 "}";
			}
		}
	}
}