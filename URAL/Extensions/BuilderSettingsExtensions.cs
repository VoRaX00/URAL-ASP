using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using URAL.Authentication;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;
using URAL.UserValidators;

namespace URAL.Extensions;

public static class BuilderSettingsExtensions
{
    private record IdentitySettings
    {
        public bool RequireConfirmedAccount { get; init; }
        public bool RequireDigit { get; init; }
        public bool RequireNonAlphanumeric { get; init; }
        public bool RequireUppercase { get; init; }
        public bool RequireLowercase { get; init; }
        public int RequiredLength { get; init; }
        public int RequiredUniqueChars { get; init; }
    }

    public static IServiceCollection AddIdentitySettings(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IUserValidator<User>, CustomUserNameValidator>();
        var settings = configuration.GetSection("Identity").Get<IdentitySettings>();
        services.AddIdentity<User, IdentityRole>(
            options =>
            {
                options.SignIn.RequireConfirmedAccount = settings.RequireConfirmedAccount;
                options.Password.RequireDigit = settings.RequireDigit;
                options.Password.RequireNonAlphanumeric = settings.RequireNonAlphanumeric;
                options.Password.RequireUppercase = settings.RequireUppercase;
                options.Password.RequireLowercase = settings.RequireLowercase;
                options.Password.RequiredLength = settings.RequiredLength;
                options.Password.RequiredUniqueChars = settings.RequiredUniqueChars;
            })
            .AddEntityFrameworkStores<UralDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }

    public static IServiceCollection AddAuthenticationSettings(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var authOptions = configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();

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

        return services;
    }

    public static IServiceCollection AddAuthorizationSettings(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(IdentityData.StaffUserPolicyName, p => p.RequireClaim(IdentityData.StaffUserClaimName, "true"));
            options.AddPolicy(IdentityData.AdminUserPolicyName, p => p.RequireClaim(IdentityData.AdminUserClaimName, "true"));
        });

        return services;
    }
}
