﻿using Tsa.CodingChallenge.Submissions.Business.Entities;
using Webstorm.Core.Data.Repositories;

namespace Tsa.CodingChallenge.Submissions.Business.Persistence
{
    public interface IUnitOfWork
    {
        bool LazyLoadingEnabled { get; set; }

        IRepository<Login> LoginsRepository { get; }

        IRepository<Problem> ProblemsRepository { get; }

        IRepository<TeamMember> TeamMembersRepository { get; }

        void BeginTransaction();

        void Commit();

        void SaveChanges();
    }
}