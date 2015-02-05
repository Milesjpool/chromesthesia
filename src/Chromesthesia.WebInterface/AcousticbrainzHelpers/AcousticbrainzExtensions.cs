using Nancy.Json;

namespace Chromesthesia.WebInterface.AcousticbrainzHelpers
{
	public static class AcousticbrainzExtensions
	{
		public static Analysis Deserialize(this AcousticbrainzResult analysis)
		{
			var hlObject = new JavaScriptSerializer().Deserialize<Analysis>(analysis.HighLevelJson);
			var llObject = new JavaScriptSerializer().Deserialize<Analysis>(analysis.LowLevelJson);
			var analysisObject = new Analysis
				{
					highlevel = hlObject.highlevel,
					lowlevel = llObject.lowlevel,
					metadata = llObject.metadata,
					rhythm = llObject.rhythm,
					tonal = llObject.tonal
				};
			return analysisObject;
		}
	}
}