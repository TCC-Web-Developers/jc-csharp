using Microsoft.EntityFrameworkCore;
using StarterAPI.Interfaces;
using StarterAPI.Middleware;
using StarterAPI.Persistence;
using StarterAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(
    options => 
    options.UseSqlite("Data Source=./student.db")
    );

//Dependency Injection - Singleton, Scoped, Transient
builder.Services.AddScoped<IApplicationDbContext>(
    provider => 
    provider.GetRequiredService<ApplicationDbContext>()
    );

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI for app services
builder.Services.AddTransient<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
