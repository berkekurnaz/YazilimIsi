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

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,List<Expression<Func<TEntity, object>>> includes = null)
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
                        if(includes.Count == 1)
                        {
                            return context.Set<TEntity>().Include(includes[0]).ToList();
                        }
                        else if(includes.Count == 2)
                        {
                            return context.Set<TEntity>().Include(includes[0]).Include(includes[1]).ToList();
                        }
                        else
                        {
                            return context.Set<TEntity>().ToList();
                        }
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
                        if (includes.Count == 1)
                        {
                            return context.Set<TEntity>().Include(includes[0]).Where(filter).ToList();
                        }
                        else if (includes.Count == 2)
                        {
                            return context.Set<TEntity>().Include(includes[0]).Include(includes[1]).Where(filter).ToList();
                        }
                        else
                        {
                            return context.Set<TEntity>().Where(filter).ToList();
                        }
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
