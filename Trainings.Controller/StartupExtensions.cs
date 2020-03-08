using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    }
}
