using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Tsa.Coding.Submissions.Blazor.Services;
using Tsa.Coding.Submissions.Core.Models;

namespace Tsa.Coding.Submissions.Blazor.Pages.Problems
{
    public partial class ProblemsOverview
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public IEnumerable<ProblemModel> Problems { get; set; }

        [Inject]
        public IProblemService ProblemService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Problems = (await ProblemService.Get()).ToList();
        }
    }
}
