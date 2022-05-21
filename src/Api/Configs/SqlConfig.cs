using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using System.Configuration;

namespace Api.Configs
{
    public static class SqlConfig
    {
        public static void AddSqlConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var database = configuration.GetConnectionString("DBConnection");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(database);
            });

        }
    }
}
