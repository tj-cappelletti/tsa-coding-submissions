using System.ComponentModel.DataAnnotations;

namespace Tsa.CodingChallenge.Submissions.Core.Entities
{
    public enum ProgrammingLanguage
    {
        C,
        [Display(Name = "C++")]
        CPlusPlus,
        [Display(Name = "C#")]
        CSharp,
        [Display(Name = "F#")]
        FSharp,
        Java,
        [Display(Name = "Node.js")]
        NodeJs,
        Perl,
        Python,
        Ruby,
        [Display(Name = "VB.NET")]
        VbDotNet
    }
}