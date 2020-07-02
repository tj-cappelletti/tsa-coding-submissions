using System.Collections.Generic;
using RestSharp;
using Tsa.CodingChallenge.Submissions.Model;

namespace Tsa.CodingChallenge.Submissions.Client
{
    public class TestDataSetsClient : WebApiClientBase, ITestDataSetsClient
    {
        private const string BaseRoute = "api/testdatasets";

        private readonly IRestClient _restClient;

        public TestDataSetsClient(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public IList<TestDataSetModel> Get()
        {
            return Get(0);
        }

        public IList<TestDataSetModel> Get(int problemId)
        {
            var request = new RestRequest(BaseRoute, Method.GET);

            if(problemId != 0)
                request.AddQueryParameter(QueryStringParameters.ProblemId, problemId.ToString());

            var response = _restClient.Execute<List<TestDataSetModel>>(request);

            CheckForOk(response);

            return response.Data;
        }

        private struct QueryStringParameters
        {
            public const string ProblemId = "problemId";
        }
    }
}