using System.Net;
using Core;
using Home_16.Helpers;
using Home_16.Models;

namespace Home_16.APITests
{
    internal class TestCaseTests : BaseApiTest
    {
        string project;

        [SetUp]
        public void SetUp()
        {
            project = projectService.GetAllProjects().GetLastEntry("result.entities[*].code").ToString();
        }
        
        [Test]
        public void GetAllTestCases()
        {
            var response = testCaseService.GetAllTestCases(project);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));

            var count = response.DeserializeJsonAndGetToken("result.total").ToObject<int>();
            var entities = response.DeserializeJsonAndGetTokens("result.entities[*]");

            Assert.AreEqual(count, entities.Count());
        }

        [Test]
        public void CreateTestCase()
        {
            var testCase = DataGenerationHelper.CreateFakeTestCase();

            var response = testCaseService.CreateTestCase(project, testCase);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));

            var testCaseId = response.DeserializeJsonAndGetToken("result.id").ToString();
            var createdTestCase = testCaseService.GetAllTestCases(project).GetElementByValue("result.entities[*]", "id", testCaseId).ToObject<TestCaseModel>();
            Assert.IsTrue(testCase.Equals(createdTestCase));
        }

        [Test]
        public void GetSpecificTestCase()
        {
            var testCaseId = testCaseService.GetAllTestCases(project).GetLastEntry("result.entities[*].id").ToObject<int>();

            var response = testCaseService.GetSpecificTestCase(project, testCaseId);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));

            var responseTestCaseId = response.DeserializeJsonAndGetToken("result.id").ToObject<int>();
            Assert.That(testCaseId, Is.EqualTo(responseTestCaseId)); 
        }
        
        [Test]
        public void DeleteTestCase()
        {
            var testCaseId = testCaseService.GetAllTestCases(project).GetLastEntry("result.entities[*].id").ToObject<int>();

            var response = testCaseService.DeleteTestCase(project, testCaseId);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));

            var responseTestCaseId = response.DeserializeJsonAndGetToken("result.id").ToObject<int>();
            Assert.That(testCaseId, Is.EqualTo(responseTestCaseId)); 
        }
        
        [Test]
        public void UpdateTestCase()
        {
            var testCaseId = testCaseService.GetAllTestCases(project).GetLastEntry("result.entities[*].id").ToObject<int>();
            var testCaseParams = DataGenerationHelper.UpdateFakeTestCase();

            var response = testCaseService.UpdateTestCase(project, testCaseId, testCaseParams);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));

            var responseTestCaseId = response.DeserializeJsonAndGetToken("result.id").ToObject<int>();
            Assert.That(testCaseId, Is.EqualTo(responseTestCaseId)); 
        }

        [Test]
        public void CreateTestCasesBulk()
        {
            var cases = DataGenerationHelper.CreateFakeTestCasesBulk(2);            

            var response = testCaseService.CreateTestCasesBulk(project, cases);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));

            var testCaseIds = response.DeserializeJsonAndGetToken("result.ids").ToObject<string[]>();
            var createdTestCases = testCaseService.GetAllTestCases(project).GetElementByValueBulk("result.entities[*]", "id", testCaseIds).ToTestCasesBulkModel();
            Assert.IsTrue(cases.Equals(createdTestCases));
        }
    }
}
