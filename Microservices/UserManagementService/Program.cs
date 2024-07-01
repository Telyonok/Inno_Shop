using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductManagementService.Application.Common.AutoMapperProfiles;
using System.Reflection;
using UserManagementService.Infrastructure.Data;
using UserManagementService.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// To add JWT Middleware. To hide into extensions.
builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDbContext")));

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new UserProfile());
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();