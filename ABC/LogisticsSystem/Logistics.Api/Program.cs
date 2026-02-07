using Logistics.Api.Data;
using Microsoft.EntityFrameworkCore;
using Logistics.Api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers() .AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.WriteIndented = true;
}); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database setup
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<DriverService>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<TripService>();


var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
