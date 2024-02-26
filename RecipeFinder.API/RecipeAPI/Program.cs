using Microsoft.Extensions.Configuration;
using RecipeAPI.Model;
using RecipeAPI.Repository;
var builder = WebApplication.CreateBuilder(args);



;
//await File.ReadAllTextAsync("../.connectionString") ?? throw new ArgumentNullException(nameof(connectionString));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UserRepository>(sp => new UserRepository(connectionString, sp.GetRequiredService<ILogger<UserRepository>>()));

builder.Services.AddSingleton<MealRepository>(sp => new MealRepository(connectionString, sp.GetRequiredService<ILogger<MealRepository>>()));

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
