

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.Data.SqlClient;

namespace LogixApi_v02.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //replace DbContex with ApplicationDbContext
        public ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public virtual IQueryable<T> Entities => _context.Set<T>().AsNoTracking();

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).Select(selector).ToListAsync();
        }
        public virtual async Task<int> GetFromSql(long id, string status)
        {
            var select = _context.SalTransactions.FromSqlRaw("select id, code, no from ").Select(s => new SalTransactionVM { Id = s.Id, Code = s.Code, No = s.No });
            
            var exe = await _context.Database.ExecuteSqlRawAsync("EXEC TestExxPros {0}, {1}", id, status);
            // var res =await  authenticate_context.Set<SysAnnouncement>().FromSqlRaw("Select Id, Subject from [dbo].[Sys_Announcement]").ToListAsync();
            return exe;
        }

        public virtual async Task<IEnumerable<R>> GetAllOther<R>() where R : class
        {
            return await _context.Set<R>().ToListAsync();
        }
        public virtual async Task<IEnumerable<R>> GetAllOther<R>(Expression<Func<R, bool>> expression) where R : class
        {
            return await _context.Set<R>().Where(expression).ToListAsync();
        }


        public virtual async Task<IEnumerable<T>> GetAll(int skip, int take)
        {
            return await _context.Set<T>().Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector)
        {
            return await _context.Set<T>().Select(selector).ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> MyGetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<R>> GetAll<R>(Expression<Func<T, R>> selector, int skip, int take)
        {
            return await _context.Set<T>().Select(selector).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression, int skip, int take)
        {
            return await _context.Set<T>().Where(expression).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<R>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).Select(selector).ToListAsync();
        }

        public virtual async Task<IEnumerable<R>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression, int skip, int take)
        {
            return await _context.Set<T>().Where(expression).Select(selector).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);

        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public EntityEntry<T> UpdateAndReturn(T entity)
        {
            var result = _context.Set<T>().Update(entity);

            return result;
        }
        public async Task<T> AddAndReturn(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);

            return result.Entity;
        }
        public T RemoveAndReturn(T entitiy)
        {
            var res = _context.Set<T>().Remove(entitiy);
            return res.Entity;

        }
        public async Task<T?> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }
        public async Task<T?> GetById(long Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public List<T> Addlist(List<T> entity)
        {
            // List<T> M = new List<T>();
            _context.AddRange(entity);
            return entity.ToList();
        }

        public async Task<T?> GetFirst(Expression<Func<T, bool>> expression)
        {
            return await Entities.FirstOrDefaultAsync(expression);
        }
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Connect(Func<SqlCommand, bool> lambda)
        {
            using (SqlConnection Conn = new SqlConnection(_context.Database.GetConnectionString()))
            {
                Conn.Open();

                using (SqlCommand Comm = Conn.CreateCommand())
                {
                    try
                    {
                        lambda(Comm);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error Connectcing to DB: --- " + e.Message);
                    }
                }
            }

        }

        public void Dispose()
        {
            _transaction?.Dispose();

            _context.Dispose();
        }






    }
}
