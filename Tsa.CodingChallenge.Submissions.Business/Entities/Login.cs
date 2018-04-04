using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tsa.CodingChallenge.Submissions.Business.Entities
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Identity { get; set; }

        public int RoleId { get; set; }

        [Required]
        [StringLength(1000)]
        public string PasswordHash { get; set; }

        [Column("RoleId")]
        public Role Role { get; set; }
    }
}
