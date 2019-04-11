using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Mvc.Models
{
    public class SubmissionViewModel
    {
        public int Id { get; set; }

        public string LoginIdentity { get; set; }

        public string ProblemName { get; set; }

        public ProgrammingLanguage ProgrammingLanguage { get; set; }

        public string ProgrammingLanguageFlags { get; set; }

        public DateTime SubmissionDateTime { get; set; }

        public DateTime? EvaluateDateTime { get; set; }
    }
}