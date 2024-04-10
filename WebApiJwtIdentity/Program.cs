using ApiProperJwt3.ErrorsHandler;
using ApiProperJwt3.StartupConfig;
using EfData;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServicesConfig.AddIdentityServices(builder);

using var loggerFactory = LoggerFactory.Create(b => b.SetMinimumLevel(LogLevel.Trace).AddConsole());

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultScheme =
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ClockSkew = new TimeSpan(0, 0, 5),
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = ctx => LogAttempt(ctx.Request.Headers, "OnChallenge"),
        OnTokenValidated = ctx => LogAttempt(ctx.Request.Headers, "OnTokenValidated")
    };
});


builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

ServicesConfig.AddSwaggerServices(builder);


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

ServicesConfig.AddDataRepositoryServices(builder);
ServicesConfig.AddHealthChecks(builder);
ServicesConfig.AddCorsService(builder);

// Global Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Default");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
}).AllowAnonymous();
app.MapHealthChecksUI();

app.Run();


Task LogAttempt(IHeaderDictionary headers, string eventType)
{
    var logger = loggerFactory.CreateLogger<Program>();
    var authorizationHeader = headers["Authorization"].FirstOrDefault();

    if (authorizationHeader is null)
    {
        logger.LogInformation($"{eventType}. JWT not present");
    }
    else
    {
        string jwtString = authorizationHeader.Substring("Bearer ".Length);

        var jwt = new JwtSecurityToken(jwtString);

        logger.LogInformation($"{eventType}. Expiration: {jwt.ValidTo.ToLongTimeString()}");
    }

    return Task.CompletedTask;
}