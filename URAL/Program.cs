using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using URAL.Application.Converters;
using URAL.Application.Extensions;
using URAL.Application.Services;
using URAL.Authentication;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;
using URAL.Infrastructure.Extension;
using URAL.UserValidators;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSwaggerGen(options =>
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2000-01-01")
    }));

builder.Services.AddDbContext<UralDbContext>(
    options =>
    {
        var connectionString = configuration.GetConnectionString("UralDbContext");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        options.UseMySql(connectionString, serverVersion);
    }
);

builder.Services.AddScoped<IUserValidator<User>, CustomUserNameValidator>();

builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 4;
        options.Password.RequiredUniqueChars = 1;
    })
    .AddEntityFrameworkStores<UralDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var authOptions = builder.Configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = authOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddSingleton<IJwtTokenWriter, JwtTokenWriter>();

builder.Services.AddSingleton(x => builder.Configuration.GetSection("MessageService").Get<MessageServiceOptions>());

var authOptions = builder.Configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();
builder.Services.AddSingleton(authOptions);

builder.Services.AddRepositories();
builder.Services.RegisterMapster();
builder.Services.AddServices();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
} );

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();