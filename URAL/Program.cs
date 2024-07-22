using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using URAL.Application.Extensions;
using URAL.Domain.Entities;
using URAL.Infrastructure;
using URAL.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<UralDbContext>(
    options =>
    {
        var connectionString = configuration.GetConnectionString("UralDbContext");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        options.UseMySql(connectionString, serverVersion);
    }
);

// builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapControllers();

app.Run();