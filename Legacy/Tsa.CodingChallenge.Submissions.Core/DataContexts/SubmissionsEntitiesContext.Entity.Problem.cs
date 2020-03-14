using Microsoft.EntityFrameworkCore;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Core.DataContexts
{
    public partial class SubmissionsEntitiesContext
    {
        private static void SetupProblemEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Problem>()
                .HasMany(e => e.Submissions)
                .WithOne(e => e.Problem);

            modelBuilder.Entity<Problem>()
                .HasMany(e => e.TestDataSets)
                .WithOne(e => e.Problem);
        }
    }
}