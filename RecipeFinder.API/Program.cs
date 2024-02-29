using Microsoft.Extensions.Configuration;
using RecipeFinder.DTO;
using RecipeFinder.Logic.Model;
using Microsoft.Extensions.Configuration.Json;
using RecipeFinder.Logic;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped(sp => new RecipeRepository(builder.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
