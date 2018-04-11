using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Business.Entities;

namespace Tsa.CodingChallenge.Submissions.Business.DataContexts
{
    public partial class SubmissionsEntitiesContext
    {
        public static void SetupProblemEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Problem>()
                .HasMany(e => e.TestDataSets)
                .WithRequired(e => e.Problem)
                .WillCascadeOnDelete(false);
        }
    }
}