// Program.cs
using DataLayer;
using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MovieContext with the connection string
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MovieDatabase")));

// Register services
builder.Services.AddTransient<DatabaseTest>();
builder.Services.AddTransient<BookmarkService>();
builder.Services.AddTransient<SearchService>();  // Register the SearchService

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

// Test the SearchService BestMatch function
using (var scope = app.Services.CreateScope())
{
    var searchService = scope.ServiceProvider.GetRequiredService<SearchService>();
    var results = await searchService.BestMatchAsync("beaumont", "bertrand"); // Test keywords

    foreach (var result in results)
    {
        Console.WriteLine($"Ranking: {result.Ranking}, Movie ID: {result.movie_id}, Movie Title: {result.movie_title}");
    }
}


app.Run();
