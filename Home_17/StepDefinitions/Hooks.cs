using Core;

namespace Home_17.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        [AfterScenario]
        public void AfterScenario()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
