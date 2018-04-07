using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tsa.CodingChallenge.Submissions.Business.Data.Annotations;

namespace Tsa.CodingChallenge.Submissions.Mvc.Models
{
    public class RegistrationViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Team Number")]
        public string Identity { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [PasswordComplexity(PasswordComplexityRules.All, 3)]
        public string Password { get; set; }
    }
}