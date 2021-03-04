using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Tsa.Coding.Submissions.Blazor.Pages.Account
{
    public partial class Details
    {
        [CascadingParameter]
        Task<AuthenticationState> authenticationStateTask { get; set; }
    }
}
