using Tsa.CodingChallenge.Submissions.Core.Entities;
using Webstorm.Core.Data.Repositories;

namespace Tsa.CodingChallenge.Submissions.Core.Persistence
{
    public interface IUnitOfWork
    {
        bool LazyLoadingEnabled { get; set; }

        IRepository<Login> LoginsRepository { get; }

        IRepository<Problem> ProblemsRepository { get; }

        IRepository<Submission> SubmissionsRepository { get; }

        IRepository<TeamMember> TeamMembersRepository { get; }

        IRepository<TestDataSetElement> TestDataSetElementsRepository { get; }

        IRepository<TestDataSet> TestDataSetsRepository { get; }

        void BeginTransaction();

        void Commit();

        void SaveChanges();
    }
}