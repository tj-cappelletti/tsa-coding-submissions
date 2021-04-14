using System;

namespace Tsa.Coding.Submissions.Blazor.Services
{
    public class TokenProvider
    {
        public string AccessToken { get; set; }
        
        public DateTimeOffset ExpiresAt { get; set; }
        
        public string RefreshToken { get; set; }
        
        public string XsrfToken { get; set; }
    }
}
