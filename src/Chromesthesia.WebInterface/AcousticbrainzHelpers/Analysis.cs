using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chromesthesia.WebInterface.AcousticbrainzHelpers
{
	
	public class Analysis
	{
		public HighLevel highlevel { get; set; }

		public class HighLevel
		{
			public Danceability danceability { get; set; }
			public Gender gender { get; set; }
			public GenreDortmund genre_dortmund { get; set; }
			public GenreAmerica genre_electronic { get; set; }
			public GenreRosamerica genre_rosamerica { get; set; }
			public GenreTzanetakis genre_tzanetakis { get; set; }
			public Isimr04Rhythm ismir04_rhythm { get; set; }
			public MoodAcoustic mood_acoustic { get; set; }
			public MoodAggressive mood_aggressive { get; set; }
			public MoodElectronic mood_electronic { get; set; }
			public MoodHappy mood_happy { get; set; }
			public MoodParty mood_party { get; set; }
			public MoodRelaxed mood_relaxed { get; set; }
			public MoodSad mood_sad { get; set; }
			public MoodsMirex moods_mirex { get; set; }
			public Timbre timbre { set; get; }
			public TonalAtonal tonal_atonal { get; set; }
			public VoiceInstrumental voice_instrumental { get; set; }

			public class Danceability
			{
				public double probability { get; set; }
				public string value { get; set; }
			}

			public class Gender
			{
				public double probability { get; set; }
				public string value { get; set; }
			}

			public class GenreDortmund
			{
			}

			public class GenreAmerica
			{
			}

			public class GenreRosamerica
			{
			}

			public class GenreTzanetakis
			{
			}

			public class Isimr04Rhythm
			{
			}

			public class MoodAcoustic
			{
				public double probability { get; set; }
				public string value { get; set; }
			}


			public class MoodAggressive
			{
				public double probability { get; set; }
				public string value { get; set; }
			}


			public class MoodElectronic
			{
				public double probability { get; set; }
				public string value { get; set; }
			}


			public class MoodHappy
			{
				public double probability { get; set; }
				public string value { get; set; }
			}


			public class MoodParty
			{
				public double probability { get; set; }
				public string value { get; set; }
			}


			public class MoodRelaxed
			{
				public double probability { get; set; }
				public string value { get; set; }
			}


			public class MoodSad
			{
				public double probability { get; set; }
				public string value { get; set; }
			}


			public class MoodsMirex
			{
				public double probability { get; set; }
				public string value { get; set; }
			}

			public class Timbre
			{
				public double probability { get; set; }
				public string value { get; set; }
			}


			public class TonalAtonal
			{
				public double probability { get; set; }
				public string value { get; set; }
			}

			public class VoiceInstrumental
			{
				public double probability { get; set; }
				public string value { get; set; }
			}
		}

		public LowLevel lowlevel { get; set; }

		public class LowLevel
		{
		}

		public Metadata metadata { get; set; }

		public class Metadata
		{
			public Tags tags { get; set; }

			public class Tags
			{
				[JsonProperty("musicbrainz album release country")]
				public List<string> musicbrainz_album_release_country;
				[JsonProperty("musicbrainz album status")]
				public string[] musicbrainz_album_status;
				[JsonProperty("musicbrainz album type")]
				public string[] musicbrainz_album_type;
				public string[] artist;
				public string[] title;
				public string[] album;
			}
		}

		public Rhythm rhythm { get; set; }

		public class Rhythm
		{
		}

		public Tonal tonal { get; set; }

		public class Tonal
		{
		}
	}
}