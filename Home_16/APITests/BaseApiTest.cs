using Home_16.Services;

namespace Home_16.APITests
{
    internal class BaseApiTest
    {
        protected ProjectService projectService;
        protected TestCaseService testCaseService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            projectService = new ProjectService();
            testCaseService = new TestCaseService();
        }
    }
}
