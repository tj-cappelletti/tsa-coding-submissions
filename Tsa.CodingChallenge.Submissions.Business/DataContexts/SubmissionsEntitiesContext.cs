using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Business.Entities;

namespace Tsa.CodingChallenge.Submissions.Business.DataContexts
{
    public class SubmissionsEntitiesContext : DbContext
    {
        public static string ConnectionStringName => "SubmissionsEntitiesContext";

        public virtual DbSet<Login> Logins { get; set; }

        public SubmissionsEntitiesContext() : base($"name={ConnectionStringName}")
        {
        }
    }
}