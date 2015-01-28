using System;
using System.Net;
using System.Reflection;
using Chromesthesia.WebInterface.HttpHelpers;
using Chromesthesia.WebInterface.Interfaces;
using Chromesthesia.WebInterface.Models;

namespace Chromesthesia.WebInterface.Services
{
	public class StatusControllerService
	{
		private readonly IAcousticbrainzExchange _acousticBrainzExchange;

		public StatusControllerService()
		{
			_acousticBrainzExchange = new AcousticbrainzExchange();
		}

		public StatusControllerService(IAcousticbrainzExchange acousticBrainzExchange)
		{
			_acousticBrainzExchange = acousticBrainzExchange;
		}

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

		private string AcousticbrainzStatus()
		{
			return _acousticBrainzExchange.GetStatus();
		}
	}
}