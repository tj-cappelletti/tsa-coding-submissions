using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Core.DataContexts
{
    public partial class SubmissionsEntitiesContext
    {
        private static void SetupTestDataSetEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestDataSet>()
                .HasMany(e => e.TestDataSetElements)
                .WithRequired(e => e.TestDataSet)
                .WillCascadeOnDelete(false);
        }
    }
}