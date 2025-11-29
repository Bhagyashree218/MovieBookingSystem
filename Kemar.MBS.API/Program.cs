using Kemar.MBS.API.Core.Helper;
using Kemar.MBS.Business.Services.Implementations;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Repositories.Implementations;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KemarMBSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
