using System;
using System.Collections.Generic;

namespace SurveyResults
{
	public class ParseData
	{
		public List<Result> results { get; set; }
	}

	public class Result
	{
		public int Blueness { get; set; }
		public string Colour { get; set; }
		public int Greenness { get; set; }
		public int Redness { get; set; }
		public int TrackId { get; set; }
		public string TrackString { get; set; }
		public DateTime createdAt { get; set; }
		public string objectId { get; set; }
		public DateTime updatedAt { get; set; }
	}
}
