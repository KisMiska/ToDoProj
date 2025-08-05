using Application.Services.Interfaces;
using Application.Services;
using Infrastructure.Persistence.Repositories;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.Core.Interfaces;

var builder = FunctionsApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("ToDoDbConnectionString");

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();


builder.ConfigureFunctionsWebApplication();

builder.Build().Run();
