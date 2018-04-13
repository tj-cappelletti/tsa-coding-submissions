using System.ComponentModel.DataAnnotations;

namespace Tsa.CodingChallenge.Submissions.Mvc.Models
{
    public class LoginDetailsViewModel
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public string Role { get; set; }

        [Display(Name = "Team Member #1")]
        public string TeamMember1 { get; set; }

        [Display(Name = "Team Member #2")]
        public string TeamMember2 { get; set; }

        [Display(Name = "Team Member #3")]
        public string TeamMember3 { get; set; }
    }
}