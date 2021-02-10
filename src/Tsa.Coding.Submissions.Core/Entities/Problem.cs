using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tsa.Coding.Submissions.Core.Entities
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

        public virtual ICollection<Submission> Submissions { get; set; }

        public virtual ICollection<TestDataSet> TestDataSets { get; set; }
    }
}
