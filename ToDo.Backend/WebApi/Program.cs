using Application.Services.Interfaces;
using Application.Services;
using Application.Validation;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Mappings;
using ToDo.Core.Interfaces;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Context;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ToDoDbConnectionString");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<ToDoDBContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile(new MappingProfile());
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateToDoItemValidator>().AddValidatorsFromAssemblyContaining<UpdateToDoItemValidator>();
builder.Services.AddTransient<IToDoRepository, ToDoRepository>().AddTransient<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
