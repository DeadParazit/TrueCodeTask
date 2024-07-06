using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrueCodeUlanYeskendirovTask.Repository;
using TrueCodeUlanYeskendirovTask.Repository.Repositories;
using TrueCodeUlanYeskendirovTask.Service.Services.Implemetations;
using TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<TrueCodeDbContext>();

builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPriorityRepository, PriorityRepository>();

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPriorityService, PriorityService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();