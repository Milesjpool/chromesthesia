using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.Interfaces
{
	public interface IAcousticbrainzExchange
	{
		string GetStatus();
		string GetAnalysis(Mbid mbid, string level);
	}
}