using PhotoSharingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace PhotoSharingApp.Data.Repository
{
    public class DefaultRepository : IDataRepository
    {
        PhotoSharingContext context;
        public DefaultRepository()
        {
            this.context = new PhotoSharingContext();
        }

        IQueryable<TEntity> IDataRepository.Filter<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        IQueryable<TEntity> IDataRepository.Filter<TEntity>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> navigationProperties)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();
            foreach (var property in navigationProperties)
            {
                queryable = queryable.Include(property);
            }
            return queryable.Where(predicate);
        }

        TEntity IDataRepository.Add<TEntity>(TEntity entity)
        {
            var photo = context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return photo;
        }

        TEntity IDataRepository.Delete<TEntity>(TEntity entity)
        {
            var photo = context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
            return photo;
        }

        TEntity IDataRepository.FindById<TEntity>(int ID)
        {
            return context.Set<TEntity>().Find(ID);
        }

        DbContextTransaction IDataRepository.BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }
    }
}
