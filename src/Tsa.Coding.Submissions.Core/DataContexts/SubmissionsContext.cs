using Microsoft.EntityFrameworkCore;
using Tsa.Coding.Submissions.Core.Entities;

namespace Tsa.Coding.Submissions.Core.DataContexts
{
    public partial class SubmissionsContext : DbContext
    {
        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Problem> Problems { get; set; }

        public virtual DbSet<Submission> Submissions { get; set; }

        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        public virtual DbSet<TestDataSet> TestDataSets { get; set; }
        public SubmissionsContext(DbContextOptions<SubmissionsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupLoginEntity(modelBuilder);
            SetupProblemEntity(modelBuilder);
            SetupTestDataSetEntity(modelBuilder);
        }
    }
}
