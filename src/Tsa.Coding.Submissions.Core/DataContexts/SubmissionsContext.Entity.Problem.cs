using Microsoft.EntityFrameworkCore;
using Tsa.Coding.Submissions.Core.Entities;

namespace Tsa.Coding.Submissions.Core.DataContexts
{
    public partial class SubmissionsContext
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
