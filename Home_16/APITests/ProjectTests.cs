using Home_16.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using Core;

namespace Home_16.APITests
{
    internal class ProjectTests : BaseApiTest
    {
        [Test]
        public void GetAllProjects()
        {
            var response = projectService.GetAllProjects();
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void GetProjectByCode()
        {
            var projectCode = "DEMO";
            var response = projectService.GetProjectByCode(projectCode);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
        
        [Test]
        public void CreateProject()
        {
            var projectModel = new CreateProjectModel()
            {
                Title = Faker.Company.Name(),
                Code = Faker.Identification.UsPassportNumber(),
                Description = Faker.Company.CatchPhrase(),
            };
            
            var response = projectService.CreateProject(projectModel);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            var createdProjectCode = response.DeserializeJsonAndGetToken("result.code").ToString();
            Assert.That(createdProjectCode, Is.EqualTo(projectModel.Code));
        }

        [Test]
        public void DeleteProject()
        {
            var projectCodeToDelete = projectService.GetAllProjects().DeserializeJsonAndGetToken("result.entities[1].code").ToString();
            var response = projectService.DeleteProject(projectCodeToDelete);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void GrantAccessToProject()
        {
            var member = new MemberModel()
            {
                Id = 2,
            };

            var projectCodeToGrant = projectService.GetAllProjects().DeserializeJsonAndGetToken("result.entities[1].code").ToString();
            var response = projectService.GrantAccessToProject(projectCodeToGrant, member);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));

            var projectMemberPair = response.DeserializeJsonAndGetToken("result").ToObject<ProjectMemberPairModel>();
            Assert.That(projectMemberPair.ProjectCode, Is.EqualTo(projectCodeToGrant));
            Assert.That(projectMemberPair.MemberId, Is.EqualTo(member.Id));
        }
        
        [Test]
        public void RevokeAccessToProject()
        {
            var member = new MemberModel()
            {
                Id = 2,
            };

            var projectCodeToRevoke = projectService.GetAllProjects().DeserializeJsonAndGetToken("result.entities[1].code").ToString();
            var response = projectService.RevokeAccessToProject(projectCodeToRevoke, member);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));

            var projectMemberPair = response.DeserializeJsonAndGetToken("result").ToObject<ProjectMemberPairModel>();
            Assert.That(projectMemberPair.ProjectCode, Is.EqualTo(projectCodeToRevoke));
            Assert.That(projectMemberPair.MemberId, Is.EqualTo(member.Id));
        }
    }
}
