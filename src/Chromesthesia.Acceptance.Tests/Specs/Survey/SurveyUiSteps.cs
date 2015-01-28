using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests.Specs.Survey
{
    public class SurveyUiSteps
    {

        private AcceptanceTestDriver _driver;

        [TestFixtureSetUp]
        public void Setup()
        {
            _driver = new AcceptanceTestDriver();
        }

        protected void When_I_navigate_to_survey_page()
        {
            _driver.NavigateToSurveyPage();
        }


        protected void Then_the_webpage_should_contain_the_required(string hexCode)
        {
            _driver.CheckResponseContains(hexCode);
        }
    }
}
