using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data;

public class TodoAppDbContext : DbContext
{
    public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Global filter for soft delete
        modelBuilder.Entity<Category>().HasQueryFilter(x => !x.DeletedAt.HasValue);
        modelBuilder.Entity<Todo>().HasQueryFilter(x => !x.DeletedAt.HasValue);
    }
}
