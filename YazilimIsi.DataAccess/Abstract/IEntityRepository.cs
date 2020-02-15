﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace YazilimIsi.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null, List<Expression<Func<T, object>>> includes = null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
