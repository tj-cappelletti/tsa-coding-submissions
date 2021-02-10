using System.ComponentModel.DataAnnotations;

namespace Tsa.Coding.Submissions.Core.Entities
{
    public class TestDataSet
    {
        [Required]
        public string Data { get; set; }

        [Required]
        public bool DisplayWithProblem { get; set; }

        [Required]
        public string ExpectedResult { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Identifier { get; set; }

        public Problem Problem { get; set; }

        [Required]
        public int ProblemId { get; set; }

        [Required]
        public int Sequence { get; set; }
    }
}
