using System.ComponentModel.DataAnnotations;
using Tsa.CodingChallenge.Submissions.Business.Data.Annotations;

namespace Tsa.CodingChallenge.Submissions.Mvc.Models
{
    public class RegistrationViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Your team number is required.")]
        [TsaIdentity(TsaIdentityType.Team)]
        [Display(Name = "Team Number")]
        public string Identity { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [PasswordComplexity(PasswordComplexityRules.All, 2)]
        public string Password { get; set; }

        [Required(ErrorMessage = "At least one team member must be entered.")]
        [Display(Name = "Team Member #1")]
        [TsaIdentity(TsaIdentityType.Individual)]
        public string TeamMember1 { get; set; }

        [Display(Name = "Team Member #2")]
        [TsaIdentity(TsaIdentityType.Individual)]
        public string TeamMember2 { get; set; }

        [Display(Name = "Team Member #3")]
        [TsaIdentity(TsaIdentityType.Individual)]
        public string TeamMember3 { get; set; }
    }
}