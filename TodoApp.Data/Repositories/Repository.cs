using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Repositories;

public class Repository<T>: IRepository<T> where T : class
{
    #region Protected Fields

    protected readonly TodoAppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    #endregion

     /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryBase{T, TDbContext}"/> class.
    /// </summary>
    /// <param name="context">The data context.</param>
    public Repository(TodoAppDbContext context)
    {
        _context = context;

        // Find Property with typeof(T) on dataContext
        var typeOfDbSet = typeof(DbSet<T>);

        foreach (var prop in context.GetType().GetProperties())
        {
            if (typeOfDbSet == prop.PropertyType)
            {
                if (prop.GetValue(context, null) is DbSet<T> value)
                {
                    _dbSet = value;
                }
                break;
            }
        }

        _dbSet ??= context.Set<T>();
    }

     #region Public Methods

    #region Create, Update, Delete
    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Add(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Update(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    #endregion

    #region Get and Search

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual T? GetById(Guid id)
    {

        return _dbSet.Find(id);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<T> GetQuery()
    {
        return _dbSet.AsQueryable();
    }

    public virtual IQueryable<T> GetQuery(
        Expression<Func<T, bool>> where)
    {
        IQueryable<T> query = _dbSet;

        if (where != null)
        {
            query = query.Where(where);
        }

        return query;
    }

    public virtual async Task<IEnumerable<T>> GetByPageAsync(
        Expression<Func<T, bool>> condition, 
        int size, int page)
    {
        return await _dbSet.Where(condition).Skip(size * (page - 1)).Take(size).ToListAsync();
    }

    #endregion

    #endregion
}
