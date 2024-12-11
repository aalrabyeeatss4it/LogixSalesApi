using LogixApi_v02.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogixApi_v02.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }     
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression);
        Task<int> GetFromSql(long id, string status);
        Task<IEnumerable<R>> GetAllOther<R>(Expression<Func<R, bool>> expression) where R : class;
        Task<IEnumerable<R>> GetAllOther<R>() where R : class;
        Task<IEnumerable<T>> GetAll(int skip, int take);
        Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> MyGetAll();
        //IList<R> GetAllmvcc<R>(Expression<Func<T, R>> selector);
        Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector, int skip, int take);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<IEnumerable<R>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression, int skip, int take);
        Task<IEnumerable<R>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression, int skip, int take);
        //Task<List<T>> FindAllwinclude(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        Task Add(T entity);
        Task<T> AddAndReturn(T entity);
        T RemoveAndReturn(T entitiy);
        void Remove(T entitiy);
        void Update(T entitiy);
        EntityEntry<T> UpdateAndReturn(T entity);
        Task<T?> GetById(int Id);
        Task<T?> GetById(long Id);
        public List<T> Addlist(List<T> entity);
        Task<T?> GetFirst(Expression<Func<T, bool>> expression);

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }

}
