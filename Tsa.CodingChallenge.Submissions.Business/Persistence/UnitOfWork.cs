using System;
using System.Data.Entity;
using Tsa.CodingChallenge.Submissions.Business.DataContexts;
using Tsa.CodingChallenge.Submissions.Business.Entities;
using Webstorm.Core.Data.Repositories;

namespace Tsa.CodingChallenge.Submissions.Business.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SubmissionsEntitiesContext _context;
        private DbContextTransaction _contextTransaction;

        public UnitOfWork(SubmissionsEntitiesContext context)
        {
            _context = context;
            _contextTransaction = null;

            LoginsRepository = new Repository<Login>(_context);
            ProblemsRepository = new Repository<Problem>(_context);
            TeamMembersRepository = new Repository<TeamMember>(_context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool LazyLoadingEnabled
        {
            get => _context.Configuration.LazyLoadingEnabled;
            set => _context.Configuration.LazyLoadingEnabled = value;
        }

        public IRepository<Login> LoginsRepository { get; }

        public IRepository<Problem> ProblemsRepository { get; }

        public IRepository<TeamMember> TeamMembersRepository { get; }

        public void BeginTransaction() { _contextTransaction = _context.Database.BeginTransaction(); }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _contextTransaction.Commit();
            }
            catch
            {
                _contextTransaction.Rollback();
                throw;
            }
            finally
            {
                _contextTransaction.Dispose();
            }
        }

        public void SaveChanges() { _context.SaveChanges(); }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_contextTransaction != null)
            {
                _contextTransaction.Rollback();
                _contextTransaction.Dispose();
            }

            _context?.Dispose();
        }
    }
}