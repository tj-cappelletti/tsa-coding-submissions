using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Business.Entities;

namespace Tsa.CodingChallenge.Submissions.Business.DataContexts
{
    public partial class SubmissionsEntitiesContext : DbContext
    {
        public SubmissionsEntitiesContext() : base($"name={ConnectionStringName}") { }

        public static string ConnectionStringName => "SubmissionsEntitiesContext";

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Problem> Problems { get; set; }

        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetupLoginEntity(modelBuilder);
            SetupTestDataSetEntity(modelBuilder);
        }
    }
}