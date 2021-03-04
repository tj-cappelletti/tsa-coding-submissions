using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Tsa.Coding.Submissions.Blazor.Services
{
    public class TokenManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TokenProvider _tokenProvider;

        public TokenManager(TokenProvider tokenProvider, IHttpClientFactory httpClientFactory)
        {
            _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<string> RetrieveAccessTokenAsync()
        {
            // should we refresh? 

            if (_tokenProvider.ExpiresAt.AddSeconds(-60).ToUniversalTime()
                > DateTime.UtcNow)
                // no need to refresh, return the access token
                return _tokenProvider.AccessToken;

            // refresh
            var idpClient = _httpClientFactory.CreateClient();

            var discoveryResponse = await idpClient
                .GetDiscoveryDocumentAsync("https://localhost:44353");

            var refreshResponse = await idpClient.RequestRefreshTokenAsync(
                new RefreshTokenRequest
                {
                    Address = discoveryResponse.TokenEndpoint,
                    ClientId = "tsa.coding.submissions.web",
                    ClientSecret = "a673bbae-71e4-4962-a623-665689c4dd34",
                    RefreshToken = _tokenProvider.RefreshToken
                });

            _tokenProvider.AccessToken = refreshResponse.AccessToken;
            _tokenProvider.RefreshToken = refreshResponse.RefreshToken;
            _tokenProvider.ExpiresAt = DateTime.UtcNow.AddSeconds(refreshResponse.ExpiresIn);

            return _tokenProvider.AccessToken;
        }
    }
}
