using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrceiPdf.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrceiPdf.Web.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //dotnet ef migrations add {name} -c OrceiPdfDbContext
            //dotnet ef database update -c OrceiPdfDbContext
            services.AddDbContext<OrceiPdfDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("OrceiPdf.Web")));
        }
    }
}
