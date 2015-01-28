using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests.Specs.Survey
{
    [TestFixture]
    public class SurveyUiSpecs : SurveyUiSteps
    {
        [TestCase("#000000")]
        public void Survey_page_should_display_required_colours(string hexCode)
        {
            When_I_navigate_to_survey_page();
            Then_the_webpage_should_contain_the_required(hexCode);
        }
    }
}