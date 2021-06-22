using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrceiPdf.Domain.Models;
using OrceiPdf.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrceiPdf.Web.Configurations
{
    public static class AuthenticationSetup
    {
        public static void AddAuthenticationSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddIdentity<User, Roles>(options => {
                options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<OrceiPdfDbContext>()
                .AddErrorDescriber<MultilanguageIdentityErrorDescriber>()
                .AddDefaultTokenProviders();
        }
    }
}
