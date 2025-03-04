using System.Linq.Expressions;
using TodoApp.Models;

namespace TodoApp.Repositories;

public interface IGenericRepository<T> : IRepository<T> where T : class, IBaseEntity
{

    /// <summary>
    /// Get Queryable entities with filter, order by, include properties and can load deleted
    /// </summary>
    /// <param name="filter">Fiter</param>
    /// <param name="orderBy">Order</param>
    /// <param name="includeProperties">Include Properties</param>
    /// <param name="canLoadDeleted">Can load delete or not</param>
    /// <returns></returns>
    IQueryable<T> Get(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "", bool canLoadDeleted = false);
    // Func<A, B> is a delegate that takes an argument of type A and returns a value of type B.

    /// <summary>
    /// Delete entity by id
    /// </summary>
    /// <param name="id">Id of the entity</param>
    void Delete(Guid id, bool isHardDelete = false);

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <param name="isHardDelete">Hard delete or sort delete</param>
    void Delete(T entity, bool isHardDelete = false);

    /// <summary>
    /// Delete entities
    /// </summary>
    /// <param name="entities">List of entity to delete</param>
    /// <param name="isHardDelete">Hard delete or sort delete</param>
    void Delete(IEnumerable<T> entities, bool isHardDelete = false);

    /// <summary>
    /// Delete entities by condition
    /// </summary>
    /// <param name="where">Condition to delete</param>
    /// <param name="isHardDelete">Hard delete or sort delete</param>
    void Delete(Expression<Func<T, bool>> where, bool isHardDelete = false);
}