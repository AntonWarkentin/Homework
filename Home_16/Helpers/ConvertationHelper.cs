using Home_16.Models;
using Newtonsoft.Json.Linq;

namespace Home_16.Helpers
{
    public static class ConvertationHelper
    {
        public static TestCasesBulkModel ToTestCasesBulkModel(this JToken[] tokens)
        {
            var cases = new TestCasesBulkModel();
            cases.Cases = new TestCaseModel[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                cases.Cases[i] = tokens[i].ToObject<TestCaseModel>();
            }

            return cases;
        }
    }
}
