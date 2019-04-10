using System.Net;
using RestSharp;
using RestSharp.Authenticators;

namespace Tsa.CodingChallenge.Submissions.Client
{
    public class CodingSubmissionsApiClient
    {
        public ITestDataSetsClient TestDataSets { get; }

        public CodingSubmissionsApiClient(string endpointUrl, string securityKey)
        {
            var restClient = new RestClient(endpointUrl)
            {
                Authenticator = new HttpBasicAuthenticator("token", "6r8D2O8kCijwNbo7")
            };

            TestDataSets = new TestDataSetsClient(restClient);

            //This will run in an isolated environment that will use self signed certs
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
        }
    }
}