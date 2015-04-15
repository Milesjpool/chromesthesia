namespace Chromesthesia.WebInterface.Exceptions
{
	public class MusicbrainzIdNotFoundException : ChromesthesiaException
	{
		private readonly string _id;

		public MusicbrainzIdNotFoundException(string id)
		{
			_id = id;
		}

		public override dynamic DefaultModel
		{
			get
			{
				return "{" +
							 "\"track_id\":\"" + _id + "\"," +
							 "\"error\":\"There doesn't seem to be a Musicbrainz ID corresponding to this 7digital track ID\"" +
							 "}";
			}
		}
	}
}