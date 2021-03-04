using System.Net.Http;

namespace Tsa.Coding.Submissions.Blazor.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenManager _tokenManager;

        public SubmissionsService(HttpClient httpClient, TokenManager tokenManager)
        {
            _httpClient = httpClient;
            _tokenManager = tokenManager;
        }
    }
}
