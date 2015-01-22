using System;
using System.Configuration;
using System.Reflection;
using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class StatusControllerService
	{

		public StatusModel GetStatusModel()
		{
			return new StatusModel
				{
					ServerTime = ServerTime(),
					Version = AssemblyVersion(),
					MachineName = MachineName(),
					AcousticbrainzStatus = AcousticbrainzStatus(),
				};
		}

		private static DateTime ServerTime()
		{
			return DateTime.Now;
		}

		private string AssemblyVersion()
		{
			return Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		private static string MachineName()
		{
			return Environment.MachineName;
		}

		private static string AcousticbrainzStatus()
		{
			var abUrl = new Uri(ConfigurationManager.ConnectionStrings["AcousticbrainzUrl"].ConnectionString);
			return new HttpHandler().StatusString(abUrl);
		}
	}
}