using DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MovieContext with the connection string
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MovieDatabase")));

// Register DatabaseTest as a transient service
builder.Services.AddTransient<DatabaseTest>();

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

// Test database connection
using (var scope = app.Services.CreateScope())
{
    var dbTest = scope.ServiceProvider.GetRequiredService<DatabaseTest>();
    dbTest.TestConnection();
}

app.Run();
