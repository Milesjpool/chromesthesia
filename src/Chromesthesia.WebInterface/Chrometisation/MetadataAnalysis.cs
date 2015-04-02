using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;

namespace Chromesthesia.WebInterface.Chrometisation
{
	public class MetadataAnalysis
	{
		private readonly Analysis _analysis;

		public MetadataAnalysis(Analysis analysis)
		{
			_analysis = analysis;
		}

		public List<string> Aggregate()
		{
			var tags = _analysis.metadata.tags;
			var album = tags.album.First();
			var artist = tags.artist.First();
			var title = tags.title.First();
			var aggregatedMetadata = new List<string>();
			aggregatedMetadata.AddRange(ToWordArray(artist));
			aggregatedMetadata.AddRange(ToWordArray(album));
			aggregatedMetadata.AddRange(ToWordArray(title));
			return aggregatedMetadata.Distinct().ToList();
		}

		private IEnumerable<string> ToWordArray(string s)
		{
			var dividers = new Regex(@"[ \-&><~/\\\(\)\[\]\.]+");
			s = dividers.Replace(s, " ");
			s = s.Replace('@', 'a');
			s = s.Replace('$', 's');
			var midWord = new Regex("(\\w)!(\\w)");
			s = midWord.Replace(s, "$1i$2");
			var nonWord = new Regex("[^\\w\\s]");
			s = nonWord.Replace(s, "");
			s = s.Trim();
			return s.ToLower().Split(' ');
		}
	}
}