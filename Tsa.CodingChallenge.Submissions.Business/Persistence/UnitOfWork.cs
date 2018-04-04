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

        public bool LazyLoadingEnabled
        {
            get => _context.Configuration.LazyLoadingEnabled;
            set => _context.Configuration.LazyLoadingEnabled = value;
        }

        public IRepository<Login> LoginsRepository { get; }

        public UnitOfWork(SubmissionsEntitiesContext context)
        {
            _context = context;
            _contextTransaction = null;

            LoginsRepository = new Repository<Login>(_context);
        }

        public void BeginTransaction()
        {
            _contextTransaction = _context.Database.BeginTransaction();
        }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_contextTransaction != null)
            {
                _contextTransaction.Rollback();
                _contextTransaction.Dispose();
            }

            if (_context != null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}