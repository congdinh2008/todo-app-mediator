using System.Linq.Expressions;

namespace TodoApp.Repositories;

public interface IRepository<T> where T : class
{
    #region CRUD Methods
    /// <summary>
    /// Add entity
    /// </summary>
    /// <param name="entity">Entity object to add</param>
    void Add(T entity);

    /// <summary>
    /// Add entities
    /// </summary>
    /// <param name="entities">List of entity to add</param>
    void Add(IEnumerable<T> entities);

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    void Update(T entity);

    /// <summary>
    /// Update entities
    /// </summary>
    /// <param name="entities">List of entity</param>
    void Update(IEnumerable<T> entities);
    #endregion

    #region Query Methods
    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <returns></returns>
    T? GetById(Guid id);

    /// <summary>
    /// Get entity by id asynchronously
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(Guid id);

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Get IQueryable entities
    /// </summary>
    /// <returns></returns>
    IQueryable<T> GetQuery();

    /// <summary>
    /// Get entities by condition
    /// </summary>
    /// <param name="where">Condition to get entities</param>
    /// <returns></returns>
    IQueryable<T> GetQuery(Expression<Func<T, bool>> where);


    /// <summary>
    /// Get entities by condition
    /// </summary>
    /// <param name="condition">Condition to get entities</param>
    /// <param name="size">Number of entity to return for each page</param>
    /// <param name="page">Page index</param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetByPageAsync(Expression<Func<T, bool>> condition, int size, int page);

    #endregion
}