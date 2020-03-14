namespace Tsa.CodingChallenge.Submissions.Core.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public Login Login { get; set; }
        public string MemberId { get; set; }
    }
}