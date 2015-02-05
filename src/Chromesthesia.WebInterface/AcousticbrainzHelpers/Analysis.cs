﻿using System.Collections.Generic;
using Nancy.Json;

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
				public string value { get; set; }
			}

			public class Gender
			{
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
			}


			public class MoodAggressive
			{
			}


			public class MoodElectronic
			{
			}


			public class MoodHappy
			{
			}


			public class MoodParty
			{
			}


			public class MoodRelaxed
			{
			}


			public class MoodSad
			{
			}


			public class MoodsMirex
			{
			}

			public class Timbre
			{
			}


			public class TonalAtonal
			{
			}

			public class VoiceInstrumental
			{
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
				public List<string> musicbrainz_album_release_country;
				public List<string> musicbrainz_album_status;
				public List<string> musicbrainz_album_type;
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