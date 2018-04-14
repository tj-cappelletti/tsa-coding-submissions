using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Business.Entities;

namespace Tsa.CodingChallenge.Submissions.Business.DataContexts
{
    public partial class SubmissionsEntitiesContext
    {
        private static void SetupLoginEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasMany(e => e.Submissions)
                .WithRequired(e => e.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.TeamMembers)
                .WithRequired(e => e.Login)
                .WillCascadeOnDelete(false);
        }
    }
}