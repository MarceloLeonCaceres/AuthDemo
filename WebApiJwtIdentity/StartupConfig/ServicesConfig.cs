using DataRepository.Implementations;
using DataRepository.Implementations.AuthAppUser;
using DataRepository.Interfaces;
using DataRepository.Interfaces.AuthAppUser;
using EfData;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Models.Entities.AuthAppUser;

namespace ApiProperJwt3.StartupConfig
{
    public static class ServicesConfig
    {
        public static void AddIdentityServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<AppUser, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddSignInManager()
            .AddRoles<Role>()
            .AddDefaultTokenProviders();
        }
        public static void AddSwaggerServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header. No hay que agregar Bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{ }
        }
    });
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApi Jwt Identity de Foad Alavi",
                    Description = "Tiene Models, EF Data, Repository y ApiControllers. Usa Refresh Token y RevokeToken" +
            "<br />Bdd = WebApiIdentityProper3" +
            @"<br />Usuarios: Admin123@example.com,
  ""password"": ""Passw0rd"". 
<br />NO Hay que escribir ""Bearer """
                });
            });
        }
        public static void AddDataRepositoryServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IRolesRepo, RolesRepo>();
            builder.Services.AddScoped<IClaimRepo, ClaimRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IUserinfoRepo, UserinfoRepo>();
        }

        public static void AddHealthChecks(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks()
                .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


            builder.Services.AddHealthChecksUI(opts =>
            {
                opts.AddHealthCheckEndpoint("api", "/health");
                opts.SetEvaluationTimeInSeconds(5);
                opts.SetMinimumSecondsBetweenFailureNotifications(10);
            }).AddInMemoryStorage();
        }

        public static void AddCorsService(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Default", p =>
                {
                    p.AllowAnyHeader();
                    p.AllowAnyMethod();
                    p.AllowAnyOrigin();
                });
            });

        }

    }
}
