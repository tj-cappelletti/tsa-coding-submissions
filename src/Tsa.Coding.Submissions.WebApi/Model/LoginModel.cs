using System.Collections.Generic;

namespace Tsa.Coding.Submissions.WebApi.Model
{
    public class LoginModel
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public virtual ICollection<TeamMemberModel> TeamMembers { get; set; }
    }
}
