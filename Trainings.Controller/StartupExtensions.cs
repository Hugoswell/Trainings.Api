namespace Trainings.Controller
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Trainings.Business;
    using Trainings.Business.Interface;
    using Trainings.Controller.Constants;
    using Trainings.Controller.Helpers;
    using Trainings.Controller.Interfaces;
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

        internal static IServiceCollection InjectControllers(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenHelper, JwtTokenHelper>();
            return services;
        }

        internal static IServiceCollection InjectManagers(this IServiceCollection services)
        {
            services.AddScoped<IAuthBusiness, AuthManager>();
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
                        //What to validate
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        
                        //Data to validate
                        ValidIssuer = "Trainings",
                        ValidAudience = "Audience",
                        IssuerSigningKey = symmetricSecurityKey,
                        //Lifetime validator
                    };
                });

            return services;
        }
    }
}
