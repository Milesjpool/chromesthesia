using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.Exceptions
{
	public class NoDataForTrackException :  ChromesthesiaException
	{
		private readonly Mbid _mbid;

		public NoDataForTrackException(Mbid mbid)
		{
			_mbid = mbid;
		}
		
		public override dynamic DefaultModel
		{
			get { return "{" +
									 "\"musicbrainz_id\":\""+_mbid+"\"," +
			             "\"error\":\"No Acousticbrainz data exists for this track\"" +
			             "}"; }
		}
	}
}