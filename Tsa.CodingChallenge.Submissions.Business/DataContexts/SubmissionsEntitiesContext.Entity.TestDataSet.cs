using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Business.Entities;

namespace Tsa.CodingChallenge.Submissions.Business.DataContexts
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