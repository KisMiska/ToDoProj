using Application.Services.Interfaces;
using Application.Services;
using Infrastructure.Persistence.Repositories;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.Core.Interfaces;
using Infrastructure.Persistence.Context;
using ToDo.Application.Mappings;
using FluentValidation;
using Application.Validation;

var builder = FunctionsApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("ToDoDbConnectionString");

builder.Services.AddDbContextFactory<ToDoDBContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(cfg => { 
    cfg.AddProfile(new MappingProfile()); 
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateToDoItemValidator>().AddValidatorsFromAssemblyContaining<UpdateToDoItemValidator>();
builder.Services.AddTransient<IToDoRepository, ToDoRepository>().AddTransient<IToDoService, ToDoService>();

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
