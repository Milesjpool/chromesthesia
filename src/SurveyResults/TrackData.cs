using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace SurveyResults
{
	public class TrackData
	{
		private readonly int _trackId;
		private readonly string _data;

		public TrackData(int trackId)
		{
			_trackId = trackId;
			_data = ParseApi.GetDataFor(_trackId);
		}

		public IList<Result> Results()
		{
			return new JavaScriptSerializer().Deserialize<ParseData>(_data).results;
		}
	}
}