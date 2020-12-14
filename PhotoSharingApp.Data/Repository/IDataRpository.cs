using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingApp.Data.Repository
{
    public interface IDataRepository
    {
        IQueryable<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        IQueryable<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> navigationProperties) where TEntity : class;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;
        TEntity FindById<TEntity>(int ID) where TEntity : class;
        TEntity Delete<TEntity>(TEntity entity) where TEntity : class;
        DbContextTransaction BeginTransaction();
    }
}
