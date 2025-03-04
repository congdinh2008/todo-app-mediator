# Migrations

## 1. Using the CLI

### Add a migration
```bash
dotnet ef migrations add AddIdentityModel --project TodoApp.MVC --startup-project TodoApp.MVC --context TodoAppDbContext --output-dir Migrations
dotnet ef migrations add [MigrationName] --project TodoApp.MVC --startup-project TodoApp.MVC --context TodoAppDbContext --output-dir Migrations
dotnet ef migrations add [MigrationName] --project TodoApp.Data --startup-project TodoApp.MVC --context StorageDbContext --output-dir Migrations/Storage
```

### Update the database
```bash
dotnet ef database update --project TodoApp.MVC --startup-project TodoApp.MVC --context TodoAppDbContext
dotnet ef database update --project TodoApp.Data --startup-project TodoApp.MVC --context StorageDbContext
```

### Roll back a migration
```bash
dotnet ef database update [MigrationName] --project TodoApp.Data --startup-project TodoApp.MVC --context TodoAppDbContext
dotnet ef database update [MigrationName] --project TodoApp.Data --startup-project TodoApp.MVC --context StorageDbContext
```

### Drop the database
```bash
dotnet ef database drop --project TodoApp.MVC --startup-project TodoApp.MVC --context TodoAppDbContext
dotnet ef database drop --project TodoApp.Data --startup-project TodoApp.MVC --context StorageDbContext
```

### Remove a migration
```bash
dotnet ef migrations remove --project TodoApp.MVC --startup-project TodoApp.MVC --context TodoAppDbContext
dotnet ef migrations remove --project TodoApp.Data --startup-project TodoApp.MVC --context StorageDbContext
```

## 2. Using the Package Manager Console
### Add a migration
```bash
Add-Migration [MigrationName] -Project TodoApp.Data -StartupProject TodoApp.MVC -Context TodoAppDbContext -OutputDir TodoApp.Data/Migrations
```

### Update the database
```bash
Update-Database -Project TodoApp.Data -StartupProject TodoApp.MVC -Context TodoAppDbContext
```

### Roll back a migration
```bash
Update-Database [MigrationName] -Project TodoApp.Data -StartupProject TodoApp.MVC -Context TodoAppDbContext
```

### Remove a migration
```bash
Remove-Migration -Project TodoApp.Data -StartupProject TodoApp.MVC -Context TodoAppDbContext
```

[]: # Path: README.md
