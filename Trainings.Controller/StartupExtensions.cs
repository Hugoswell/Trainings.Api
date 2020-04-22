namespace Trainings.Controller
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Text;
    using Trainings.Business;
    using Trainings.Business.Helper;
    using Trainings.Business.Helpers;
    using Trainings.Business.Interfaces;
    using Trainings.Common.Constants;
    using Trainings.Data.Context;
    using Trainings.Repository;
    using Trainings.Repository.Interfaces;

    internal static class StartupExtensions
    {
        internal static IServiceCollection AddContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TrainingsEntities>(options => options.UseSqlServer(connectionString));
            return services;
        }

        internal static IServiceCollection InjectHelpers(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenHelper, JwtTokenHelper>();
            services.AddScoped<IHasher, Hasher>();
            return services;
        }

        internal static IServiceCollection InjectManagers(this IServiceCollection services)
        {            
            services.AddScoped<IAuthManager, AuthManager>();
            return services;
        }

        internal static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            return services;
        }

        internal static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            string secretKey = configuration[AppSettings.SecretKey];
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Data to validate
                        ValidateIssuer = false,      //Mandatory
                        ValidateAudience = false,    //Mandatory
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = symmetricSecurityKey,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}
