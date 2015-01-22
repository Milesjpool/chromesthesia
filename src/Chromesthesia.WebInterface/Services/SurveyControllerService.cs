using System.Web.Mvc;

namespace Chromesthesia.WebInterface.Services
{
	public class SurveyControllerService : Controller
	{
		public SurveyModel GetSurveyModel()
		{
			return new SurveyModel();
		}
	}
}