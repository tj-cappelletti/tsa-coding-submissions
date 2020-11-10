using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tsa.CodingChallenge.Submissions.Core.Repositories
{
    public interface IRepositoryReader<TEntity>
    {
        bool Any(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Get();

        TEntity Get(int id);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}