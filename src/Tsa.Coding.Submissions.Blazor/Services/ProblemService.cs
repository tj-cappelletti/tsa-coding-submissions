using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityModel.Client;
using Tsa.Coding.Submissions.Core.Models;

namespace Tsa.Coding.Submissions.Blazor.Services
{
    public class ProblemService : IProblemService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenManager _tokenManager;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

        public ProblemService(HttpClient httpClient, TokenManager tokenManager)
        {
            _httpClient = httpClient;
            _tokenManager = tokenManager;
        }

        public async Task<IEnumerable<ProblemModel>> Get()
        {
            _httpClient.SetBearerToken(await _tokenManager.RetrieveAccessTokenAsync());

            var stream = await _httpClient.GetStreamAsync("api/problems");

            var problemModels = await JsonSerializer.DeserializeAsync<IEnumerable<ProblemModel>>(stream, JsonSerializerOptions);

            return problemModels;
        }

        public async Task<ProblemModel> Get(int id)
        {
            _httpClient.SetBearerToken(await _tokenManager.RetrieveAccessTokenAsync());

            var stream = await _httpClient.GetStreamAsync($"api/problems/{id}");

            var problemModel = await JsonSerializer.DeserializeAsync<ProblemModel>(stream, JsonSerializerOptions);

            return problemModel;
        }
    }
}
