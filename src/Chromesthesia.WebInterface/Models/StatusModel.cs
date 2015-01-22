using System;

namespace Chromesthesia.WebInterface.Models
{
	public class StatusModel
	{
		public DateTime ServerTime { get; set; }
		public string Version { get; set; }
		public string MachineName { get; set; }
		public string AcousticbrainzStatus { get; set; }
	}
}