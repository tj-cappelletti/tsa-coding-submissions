using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsa.CodingChallenge.Submissions.Business.Entities;

namespace Tsa.CodingChallenge.Submissions.Business.DataContexts
{
    public partial class SubmissionsEntitiesContext
    {
        private static void SetupLoginEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasMany(e => e.TeamMembers)
                .WithRequired(e => e.Login)
                .WillCascadeOnDelete(false);
        }
    }
}
