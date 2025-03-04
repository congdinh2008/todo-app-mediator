# Add package for TodoApp.Models
dotnet add TodoApp.Models package Microsoft.EntityFrameworkCore
dotnet add TodoApp.Models package Microsoft.AspNetCore.Identity.EntityFrameworkCore

# Add package for TodoApp.Business
dotnet add TodoApp.Business package Microsoft.EntityFrameworkCore
dotnet add TodoApp.Business package MediatR
dotnet add TodoApp.Business package AutoMapper
dotnet add TodoApp.Business package Newtonsoft.Json

# Add package for TodoApp.Data
dotnet add TodoApp.Data package Microsoft.EntityFrameworkCore
dotnet add TodoApp.Data package Microsoft.EntityFrameworkCore.SqlServer
dotnet add TodoApp.Data package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add TodoApp.Data package Microsoft.AspNetCore.Identity

# Add package for TodoApp.MVC
dotnet add TodoApp.MVC package Microsoft.EntityFrameworkCore
dotnet add TodoApp.MVC package Microsoft.EntityFrameworkCore.SqlServer
dotnet add TodoApp.MVC package Microsoft.EntityFrameworkCore.Design
dotnet add TodoApp.MVC package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add TodoApp.MVC package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add TodoApp.MVC package Microsoft.AspNetCore.Identity.UI
dotnet add TodoApp.MVC package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add TodoApp.MVC package Microsoft.AspNetCore.Mvc.Versioning
dotnet add TodoApp.MVC package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
dotnet add TodoApp.MVC package Swashbuckle.AspNetCore
dotnet add TodoApp.MVC package Swashbuckle.AspNetCore.Swagger
dotnet add TodoApp.MVC package Swashbuckle.AspNetCore.SwaggerGen
dotnet add TodoApp.MVC package Swashbuckle.AspNetCore.SwaggerUI
dotnet add TodoApp.MVC package Microsoft.Extensions.Configuration
