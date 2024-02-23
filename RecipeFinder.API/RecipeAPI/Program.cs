using Microsoft.Extensions.Configuration;
using RecipeAPI.Model;
using RecipeAPI.Repository;
var builder = WebApplication.CreateBuilder(args);


string connectionString = "Server=tcp:nimaserver.database.windows.net,1433;Initial Catalog=Revature;Persist Security Info=False;User ID=NDJAVID;Password=Nimaji909$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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