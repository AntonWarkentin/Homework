using Home_16.Models;

namespace Home_16.Helpers
{
    public static class DataGenerationHelper
    {
        public static TestCaseModel CreateFakeTestCase()
        {
            return new TestCaseModel()
            {
                Title = "test_" + Faker.Name.Last(),
                Description = "description_" + Faker.RandomNumber.Next(),
                IsFlaky = Convert.ToInt32(Faker.Boolean.Random()),
                Postconditions = "postcon_" + Faker.Country.Name(),
            };
        }

        public static TestCasesBulkModel CreateFakeTestCasesBulk(int amountOfCases)
        {
            var cases = new TestCasesBulkModel();
            cases.Cases = new TestCaseModel[amountOfCases];

            for (int i = 0; i < amountOfCases; i++)
            {
                cases.Cases[i] = CreateFakeTestCase();
            }

            return cases;
        }

        public static TestCaseModel UpdateFakeTestCase()
        {
            return new TestCaseModel()
            {
                Description = "changed_" + Faker.RandomNumber.Next(),
                Preconditions = "precon_" + Faker.Country.Name(),
                Postconditions = "postcon_changed_" + Faker.Country.Name(),
            };
        }
    }
}
