using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Chromesthesia.WebInterface.Services
{
	public static class SurveyTracks
	{
		public static Dictionary<int, string> GetDictionaryOfPaths()
		{
			var trackHashtable = (ConfigurationManager.GetSection("TrackList") as System.Collections.Hashtable);
			var dictionaryOfPaths = trackHashtable.Cast<System.Collections.DictionaryEntry>().ToDictionary(n => int.Parse(n.Key.ToString()), n => n.Value.ToString());
			return dictionaryOfPaths;
		}
	}
}