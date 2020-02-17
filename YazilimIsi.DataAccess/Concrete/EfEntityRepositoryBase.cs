using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YazilimIsi.DataAccess.Abstract;

namespace YazilimIsi.DataAccess.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            using (TContext context = new TContext())
            {
                if (includes == null)
                {
                    return context.Set<TEntity>().SingleOrDefault(filter);
                }
                else
                {
                    var query = context.Set<TEntity>().AsQueryable();
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                    return query.SingleOrDefault(filter);
                }
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,params Expression<Func<TEntity, object>>[] includes)
        {
            using (TContext context = new TContext())
            {
                if (filter == null)
                {
                    if (includes == null)
                    {
                        return context.Set<TEntity>().ToList();
                    }
                    else
                    {
                        var query = context.Set<TEntity>().AsQueryable();
                        query = includes.Aggregate(query,(current, include) => current.Include(include));
                        return query.ToList();
                    }
                }
                else
                {
                    if (includes == null)
                    {
                        return context.Set<TEntity>().Where(filter).ToList();
                    }
                    else
                    {
                        var query = context.Set<TEntity>().Where(filter).AsQueryable();
                        query = includes.Aggregate(query, (current, include) => current.Include(include));
                        return query.ToList();
                    }
                }
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
