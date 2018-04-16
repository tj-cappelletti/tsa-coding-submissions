using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tsa.CodingChallenge.Submissions.Core.Entities
{
    public class TestDataSet
    {
        [Required]
        public bool DisplayWithProblem { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Identifier { get; set; }

        public Problem Problem { get; set; }

        [Required]
        public int ProblemId { get; set; }

        [Required]
        public int Sequence { get; set; }

        public virtual ICollection<TestDataSetElement> TestDataSetElements { get; set; }
    }
}