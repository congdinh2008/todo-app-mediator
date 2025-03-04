
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly TodoAppDbContext _context;
    private bool _disposed = false;

    public UnitOfWork(TodoAppDbContext context)
    {
        _context = context;
    }

    public TodoAppDbContext Context => _context;

    private IGenericRepository<Category>? _categoryRepository;

    public IGenericRepository<Category> CategoryRepository => _categoryRepository ??= new GenericRepository<Category>(_context);

    private IGenericRepository<Todo>? _todoRepository;

    public IGenericRepository<Todo> TodoRepository => _todoRepository ??= new GenericRepository<Todo>(_context);
    public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity => new GenericRepository<T>(_context);

    public IRepository<T> Repository<T>() where T : class => new Repository<T>(_context);

    public async Task<int> SaveChangesAsync()
    {
        BeforeSaveChanges();
        return await _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        BeforeSaveChanges();
        return _context.SaveChanges();
    }

    private void BeforeSaveChanges()
    {
        var entities = _context.ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var baseEntity = (BaseEntity)entity.Entity;
            switch (entity.State)
            {
                case EntityState.Added:
                    baseEntity.InsertedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    baseEntity.UpdatedAt = DateTime.Now;
                    break;
            }
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}