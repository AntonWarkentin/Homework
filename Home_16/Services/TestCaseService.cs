﻿using Home_16.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using RestSharp;

namespace Home_16.Services
{
    public class TestCaseService : BaseService
    {
        public string ProjectEndpoint = "/case/{code}";
        public string TestCaseEndpoint = "/case/{code}/{id}";
        public string TestCaseBulkEndpoint = "/case/{code}/bulk";

        public TestCaseService() : base()
        {
            apiClient.AddToken();
        }

        public RestResponse GetAllTestCases(string projectCode)
        {
            var request = new RestRequest(ProjectEndpoint).AddUrlSegment("code", projectCode).AddQueryParameter("limit", "100");
            return apiClient.Execute(request);
        }

        public RestResponse CreateTestCase(string projectCode, TestCaseModel testCase)
        {
            var request = new RestRequest(ProjectEndpoint, Method.Post).AddUrlSegment("code", projectCode);
            request.AddBody(JsonConvert.SerializeObject(testCase), ContentType.Json);
            return apiClient.Execute(request);
        }

        public RestResponse GetSpecificTestCase(string projectCode, int testCaseId)
        {
            var request = new RestRequest(TestCaseEndpoint).AddUrlSegment("code", projectCode).AddUrlSegment("id", testCaseId);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteTestCase(string projectCode, int testCaseId)
        {
            var request = new RestRequest(TestCaseEndpoint, Method.Delete).AddUrlSegment("code", projectCode).AddUrlSegment("id", testCaseId);
            return apiClient.Execute(request);
        }

        public RestResponse UpdateTestCase(string projectCode, int testCaseId, TestCaseModel testCase)
        {
            var request = new RestRequest(TestCaseEndpoint, Method.Patch).AddUrlSegment("code", projectCode).AddUrlSegment("id", testCaseId);
            request.AddBody(JsonConvert.SerializeObject(testCase), ContentType.Json);
            return apiClient.Execute(request);
        }

        public RestResponse CreateTestCasesBulk(string projectCode, TestCasesBulkModel cases)
        {
            var request = new RestRequest(TestCaseBulkEndpoint, Method.Post).AddUrlSegment("code", projectCode);
            request.AddBody(JsonConvert.SerializeObject(cases), ContentType.Json);
            return apiClient.Execute(request);
        }
    }
}