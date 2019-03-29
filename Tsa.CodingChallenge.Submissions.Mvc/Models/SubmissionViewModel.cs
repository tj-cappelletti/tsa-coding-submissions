using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Mvc.Models
{
    public class SubmissionViewModel
    {
        [Display(Name = "Source Code File")]
        public IFormFile FileUpload { get; set; }

        public string ProblemName { get; set; }

        [Required]
        [Display(Name = "Language")]
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}