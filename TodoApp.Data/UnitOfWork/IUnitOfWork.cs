using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    TodoAppDbContext Context { get; }

    IGenericRepository<Category> CategoryRepository { get; }

    IGenericRepository<Todo> TodoRepository { get; }

    IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;

    IRepository<T> Repository<T>() where T : class;

    Task<int> SaveChangesAsync();

    int SaveChanges();
}