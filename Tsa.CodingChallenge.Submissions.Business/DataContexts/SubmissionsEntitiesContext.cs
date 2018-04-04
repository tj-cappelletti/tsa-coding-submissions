using System.Data.Entity;

namespace Tsa.CodingChallenge.Submissions.Business.DataContexts
{
    public class SubmissionsEntitiesContext : DbContext
    {
        public SubmissionsEntitiesContext() : base("name=SubmissionsEntitiesContext")
        {
        }
    }
}