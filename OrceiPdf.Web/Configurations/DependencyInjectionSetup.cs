using Microsoft.Extensions.DependencyInjection;
using OrceiPdf.IoC;
using OrceiPdf.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrceiPdf.Web.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);

            services.AddScoped(typeof(RenderViewComponentService));
        }
    }
}
