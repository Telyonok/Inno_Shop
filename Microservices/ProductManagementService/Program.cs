using ProductManagementService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ProductManagementService.Application.Common.AutoMapperProfiles;
using FluentValidation;
using ProductManagementService.Application.Products.Commands.CreateProduct;
using ProductManagementService.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// To add Exception Middleware, JWT Middleware. To hide into extensions.
builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDbContext")));

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new ProductProfile());
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