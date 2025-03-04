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
}
