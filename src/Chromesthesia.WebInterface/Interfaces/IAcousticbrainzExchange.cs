using Chromesthesia.WebInterface.AcousticbrainzHelpers;
using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.Interfaces
{
	public interface IAcousticbrainzExchange
	{
		string GetStatus();
		AcousticbrainzResult GetAnalysisOf(Mbid mbid);
	}
}