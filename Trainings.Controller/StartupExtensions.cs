using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Trainings.Controller.Constants;
using Trainings.Data.Context;

namespace Trainings.Controller
{
    internal static class StartupExtensions
    {
        internal static IServiceCollection AddContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TrainingsEntities>(options => options.UseSqlServer(connectionString));
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
                        
                        //Data to validate
                        ValidIssuer = "hugo",
                        ValidAudience = "readers",
                        IssuerSigningKey = symmetricSecurityKey
                    };
                });

            return services;
        }
    }
}
