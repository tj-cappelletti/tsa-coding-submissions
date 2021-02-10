using Microsoft.EntityFrameworkCore;
using Tsa.Coding.Submissions.Core.Entities;

namespace Tsa.Coding.Submissions.Core.DataContexts
{
    public partial class SubmissionsContext
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
