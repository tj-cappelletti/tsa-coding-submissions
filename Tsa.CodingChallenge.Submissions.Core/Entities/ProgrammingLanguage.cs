using System.ComponentModel.DataAnnotations;

namespace Tsa.CodingChallenge.Submissions.Core.Entities
{
    public enum ProgrammingLanguage
    {
        [Display(Name = ".NET (C#, F#, VB.NET)")]
        DotNet = 1,
        [Display(Name = "C/C++")]
        C = 2,
        Java = 3,
        [Display(Name = "Node.js")]
        NodeJs = 4,
        Perl = 5,
        Python = 6,
        Ruby = 7
    }
}