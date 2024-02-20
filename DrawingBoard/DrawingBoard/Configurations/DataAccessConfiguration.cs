using DrawingBoard.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DrawingBoard.Configurations
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            string connectionString = configuration.GetConnectionString("DatabaseConnection")!;
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
