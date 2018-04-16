using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Core.DataContexts
{
    public partial class SubmissionsEntitiesContext : DbContext
    {
        public static string ConnectionStringName => "SubmissionsEntitiesContext";

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Problem> Problems { get; set; }

        public virtual DbSet<Submission> Submissions { get; set; }

        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        public virtual DbSet<TestDataSetElement> TestDataSetElements { get; set; }

        public virtual DbSet<TestDataSet> TestDataSets { get; set; }

        public SubmissionsEntitiesContext() : base($"name={ConnectionStringName}")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetupLoginEntity(modelBuilder);
            SetupProblemEntity(modelBuilder);
            SetupTestDataSetEntity(modelBuilder);
        }
    }
}