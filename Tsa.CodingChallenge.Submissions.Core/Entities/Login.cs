using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tsa.CodingChallenge.Submissions.Core.Entities
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Identity { get; set; }

        [Required]
        [StringLength(1000)]
        public string PasswordHash { get; set; }

        [Column("RoleId")]
        public Role Role { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}