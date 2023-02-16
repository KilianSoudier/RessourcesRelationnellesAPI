using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RessourcesRelationnellesAPI.Models;

namespace RessourcesRelationnellesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>((provider, options) => {
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConn")));
                IConfiguration config = provider.GetRequiredService<IConfiguration>();
                string connectionString = config.GetConnectionString("DefaultConn");
                options.UseSqlServer(connectionString);
            });
        }
    }
}
