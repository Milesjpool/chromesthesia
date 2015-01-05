namespace Chromesthesia.WebInterface
{
    public class SurveyPage : IWebPage<object>
    {
        private readonly Routes _routes;

        public SurveyPage(Routes routes)
        {
            _routes = routes;
        }

        public dynamic Render()
        {
            return _routes.View["Pages/SurveyPage.html"];
        }
    }
}