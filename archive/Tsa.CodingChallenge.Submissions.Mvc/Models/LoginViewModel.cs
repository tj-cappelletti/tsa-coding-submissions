using System.ComponentModel.DataAnnotations;

namespace Tsa.CodingChallenge.Submissions.Mvc.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Team Number")]
        public string Identity { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}