using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Repositories;

public class GenericRepository<T> : Repository<T>, IGenericRepository<T> where T : class, IBaseEntity
{
    public GenericRepository(TodoAppDbContext context) : base(context)
    {
        
    }

    #region Public Methods

    #region Create, Update, Delete
    public virtual void Delete(T entity, bool isHardDelete = false)
    {
        if (isHardDelete)
        {
            _dbSet.Remove(entity);
        }
        else
        {
            entity.DeletedAt = DateTime.Now;
            _dbSet.Update(entity);
        }
    }

    public virtual void Delete(Guid id, bool isHardDelete = false)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            Delete(entity, isHardDelete);
        }
    }

    public virtual void Delete(IEnumerable<T> entities, bool isHardDelete = false)
    {
        if (isHardDelete)
        {
            _dbSet.RemoveRange(entities);
        }
        else
        {
            foreach (var entity in entities)
            {
                entity.DeletedAt = DateTime.Now;
                _dbSet.Update(entity);
            }
        }
    }

    public virtual void Delete(Expression<Func<T, bool>> where, bool isHardDelete = false)
    {
        var entities = _dbSet.Where(where).ToList();
        Delete(entities, isHardDelete);
    }

    #endregion

    #region Get and Search

    public virtual IQueryable<T> Get(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "",
        bool canLoadDeleted = false)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!canLoadDeleted)
        {
            query = query.Where(x => x.DeletedAt == null);
        }

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return orderBy != null ? orderBy(query) : query;
    }

    #endregion

    #endregion
}