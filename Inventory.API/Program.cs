using FluentValidation;
using FluentValidation.AspNetCore;
using Inventory.API.Dtos.Category.Validators;
using Inventory.Application.Category.Commands.CreateCategory;
using Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddControllers();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(CreateCategoryCommand).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly).AddFluentValidationAutoValidation();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
