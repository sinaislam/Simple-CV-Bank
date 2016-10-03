﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public interface IRepository<T>
        where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        void Save();

        T Find(object id);
        T Find(Expression<Func<T, bool>> filter);

        T FindIncluding(Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll();
        IQueryable<T> FindAll(Expression<Func<T, bool>> filter);
        IQueryable<T> FindAllIncluding(params Expression<Func<T, object>>[] includeProperties);
    }
}