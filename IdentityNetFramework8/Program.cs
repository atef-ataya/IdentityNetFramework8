using IdentityNetFramework8;
using IdentityNetFramework8.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup Identity - Configure the identity to use cookie-based authentication and enable authorization
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddAuthorization();

// Configure the EF Core Database. Use the in-memory database 
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDb"));

// Configure identity to use the EF Core database & expose the identity endpoints
builder.Services.AddIdentityCore<MyUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

// Map the routes for the identity endpoints
app.MapIdentityApi<MyUser>();

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
