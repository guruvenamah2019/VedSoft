using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedSoft.Logger;
using VedSoft.Data.Contracts.Wrapper;
using VedSoft.Data.Repository;
using VedSoft.Logger;
using Swashbuckle.AspNetCore.Swagger;
using VedSoft.Business.Engine.Master;
using VedSoft.Business.Master;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using VedSoft.API.Util;
using VedSoft.Business.Login;
using VedSoft.Business.Login;
using VedSoft.API.Util.Token;

namespace VedSoft.API.Core
{
    public static class ServiceExtensions
    {
        //To enable cors
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        //to configure swagger
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swg =>
            {
                swg.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "VedSoft API",
                    Description = "API Project for VedSoft",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "VedSoft",  }
                });
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            
        }

        //It has been done like this
        //so that it should work in Docker
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var appConfigValue = config.GetSection("AppSettings");
            string mySqlConnectionString = "server=SERVER;userid=USERID;password=PASSWORD;database=DATABASE;";

            //var conServer = Environment.GetEnvironmentVariable("VedSoftDBConnString_server");
            //var conUserID = Environment.GetEnvironmentVariable("VedSoftDBConnString_userid");
            //var conPassword = Environment.GetEnvironmentVariable("VedSoftDBConnString_password");
            //var conDatabase = Environment.GetEnvironmentVariable("VedSoftDBConnString_database");

            var conServer = appConfigValue.GetSection("VedSoftDBConnString_server").Value;
            var conUserID = appConfigValue.GetSection("VedSoftDBConnString_userid").Value;
            var conPassword = appConfigValue.GetSection("VedSoftDBConnString_password").Value;
            var conDatabase = appConfigValue.GetSection("VedSoftDBConnString_database").Value;

            mySqlConnectionString = mySqlConnectionString.Replace("SERVER", conServer)
                                                            .Replace("USERID", conUserID)
                                                            .Replace("PASSWORD", conPassword)
                                                            .Replace("DATABASE", conDatabase);

            Program._log.InfoFormat("DB Connection String:{0}", mySqlConnectionString);
            services.AddDbContext<RepositoryContext>(mySql => mySql.UseMySql(mySqlConnectionString));
        }

        //To configure dependency injection
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            // Apply dependency injection start
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IMasterBusinessEngine, MasterBusinessEngine>();
            services.AddScoped<IMasterBusiness, MasterBusiness>();
            services.AddScoped<ILoginBusinessEngine, LoginBusinessEngine>();
            services.AddScoped<ILoginBusiness, LoginBusiness>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddSingleton<IVedSoftLogger, Logger.Logger>();
        }

        //To configure the JWT token
        public static void ConfigureJWTToken(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "bearer";
            }).AddJwtBearer("bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigKey.JWTSecurityKey)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration config)
        {
            var appConfigValue = config.GetSection("AppSettings");
            ConfigKey.JWTSecurityKey= appConfigValue.GetSection("JWTSecurityKey").Value;
            ConfigKey.JWTAccessTokenDurationInSeconds= Convert.ToInt32(appConfigValue.GetSection("JWTAccessTokenDurationInSeconds").Value);
            ConfigKey.JWTTokenAudience= appConfigValue.GetSection("JWTTokenAudience").Value;
            ConfigKey.JWTTokenIssuer = appConfigValue.GetSection("JWTTokenIssuer").Value;
        }
    }
}
