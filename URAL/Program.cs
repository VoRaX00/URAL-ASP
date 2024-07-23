using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using URAL.Application.Extensions;
using URAL.Application.Services;
using URAL.Authentication;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;
using URAL.Infrastructure.Extension;
using URAL.UserValidators;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSwaggerGen();

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

builder.Services.AddSingleton(x => builder.Configuration.GetSection("MessageService").Get<MessageServiceOptions>());

var authOptions = builder.Configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();
builder.Services.AddSingleton(authOptions);

builder.Services.AddRepositories();
builder.Services.RegisterMapster();
builder.Services.AddServices();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();