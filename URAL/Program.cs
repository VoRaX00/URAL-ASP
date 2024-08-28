using Microsoft.EntityFrameworkCore;
using URAL.Application.Extensions;
using URAL.Application.Services;
using URAL.Authentication;
using URAL.Infrastructure.Context;
using URAL.Infrastructure.Extension;
using URAL.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using URAL.Hubs;
using URAL.Swagger;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddDbContext<UralDbContext>(
    options => { options.UseNpgsql(configuration.GetConnectionString(nameof(UralDbContext))); }
);

builder.Services.AddIdentitySettings(configuration);

builder.Services.AddAuthenticationSettings(configuration);

builder.Services.AddAuthorizationSettings();

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
        policy.WithOrigins("http://bscar-go.ru", "http://www.bscar-go.ru", "http://localhost:3000");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
    });
} );

var app = builder.Build();

app.MapHub<ChatHub>("/chat");

app.UseCors();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();