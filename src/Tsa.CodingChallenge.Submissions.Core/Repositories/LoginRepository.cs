using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;
using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Core.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SubmissionsContext _submissionsContext;

        public LoginRepository(SubmissionsContext submissionsContext)
        {
            _submissionsContext = submissionsContext;
        }

        public Login Add(Login entity)
        {
            return AddAsync(entity).Result;
        }

        public async Task<Login> AddAsync(Login entity)
        {
            var addedEntity = await _submissionsContext.AddAsync(entity);
            await _submissionsContext.SaveChangesAsync();

            return addedEntity.Entity;
        }

        public bool Any(Expression<Func<Login, bool>> predicate)
        {
            return AnyAsync(predicate).Result;
        }

        public async Task<bool> AnyAsync(Expression<Func<Login, bool>> predicate)
        {
            return await _submissionsContext.Logins.AnyAsync(predicate);
        }

        public void Delete(Login entity)
        {
            _submissionsContext.Remove(entity);
            _submissionsContext.SaveChanges();
        }

        public async Task DeleteAsync(Login entity)
        {
            _submissionsContext.Remove(entity);
            await _submissionsContext.SaveChangesAsync();
        }

        public IEnumerable<Login> Get()
        {
            return GetAsync().Result;
        }

        public Login Get(int id)
        {
            return GetAsync(id).Result;
        }

        public async Task<IEnumerable<Login>> GetAsync()
        {
            return await _submissionsContext.Logins.ToListAsync();
        }

        public async Task<Login> GetAsync(int id)
        {
            return await _submissionsContext.Logins.SingleOrDefaultAsync(l => l.Id == id);
        }

        public Login SingleOrDefault(Expression<Func<Login, bool>> predicate)
        {
            return SingleOrDefaultAsync(predicate).Result;
        }

        public async Task<Login> SingleOrDefaultAsync(Expression<Func<Login, bool>> predicate)
        {
            return await _submissionsContext.Logins.SingleOrDefaultAsync(predicate);
        }

        public void Update(Login entity)
        {
            var foundLogin = _submissionsContext.Logins.Single(l => l.Id == entity.Id);

            UpdateLoginEntity(entity, foundLogin);

            _submissionsContext.SaveChanges();
        }

        public async Task UpdateAsync(Login entity)
        {
            var foundLogin = await _submissionsContext.Logins.SingleAsync(l => l.Id == entity.Id);

            UpdateLoginEntity(entity, foundLogin);

            await _submissionsContext.SaveChangesAsync();
        }

        private static void UpdateLoginEntity(Login updatedLogin, Login foundLogin)
        {
            foundLogin.Identity = updatedLogin.Identity;
            foundLogin.PasswordHash = updatedLogin.PasswordHash;
        }

        public IEnumerable<Login> Where(Expression<Func<Login, bool>> predicate)
        {
            return WhereAsync(predicate).Result;
        }

        public async Task<IEnumerable<Login>> WhereAsync(Expression<Func<Login, bool>> predicate)
        {
            return await _submissionsContext.Logins.Where(predicate).ToListAsync();
        }
    }
}