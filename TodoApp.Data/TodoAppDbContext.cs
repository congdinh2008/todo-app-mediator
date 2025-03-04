﻿using Microsoft.EntityFrameworkCore;

namespace TodoApp.Data;

public class TodoAppDbContext : DbContext
{
    public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options)
    {
    }
}
