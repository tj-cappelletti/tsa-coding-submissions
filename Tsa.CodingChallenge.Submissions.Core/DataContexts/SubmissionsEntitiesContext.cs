using Microsoft.EntityFrameworkCore;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Core.DataContexts
{
    public partial class SubmissionsEntitiesContext : DbContext
    {
        public SubmissionsEntitiesContext(DbContextOptions<SubmissionsEntitiesContext> options) : base(options) { }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Problem> Problems { get; set; }

        public virtual DbSet<Submission> Submissions { get; set; }

        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        public virtual DbSet<TestDataSet> TestDataSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupLoginEntity(modelBuilder);
            SetupProblemEntity(modelBuilder);
            SetupTestDataSetEntity(modelBuilder);
        }
    }
}