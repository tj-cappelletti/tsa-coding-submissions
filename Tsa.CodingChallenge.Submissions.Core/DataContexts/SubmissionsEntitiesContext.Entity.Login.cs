using Microsoft.EntityFrameworkCore;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Core.DataContexts
{
    public partial class SubmissionsEntitiesContext
    {
        private static void SetupLoginEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasMany(e => e.Submissions)
                .WithOne(e => e.Login);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.TeamMembers)
                .WithOne(e => e.Login);
        }
    }
}