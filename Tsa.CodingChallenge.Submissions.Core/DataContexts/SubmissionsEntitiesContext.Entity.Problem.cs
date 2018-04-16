using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Core.DataContexts
{
    public partial class SubmissionsEntitiesContext
    {
        private static void SetupProblemEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Problem>()
                .HasMany(e => e.Submissions)
                .WithRequired(e => e.Problem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Problem>()
                .HasMany(e => e.TestDataSets)
                .WithRequired(e => e.Problem)
                .WillCascadeOnDelete(false);
        }
    }
}