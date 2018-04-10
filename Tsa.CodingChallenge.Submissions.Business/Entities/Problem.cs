using System.ComponentModel.DataAnnotations;

namespace Tsa.CodingChallenge.Submissions.Business.Entities
{
    public class Problem
    {
        public string Description { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Identifier { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}