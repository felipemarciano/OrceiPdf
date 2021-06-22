using Microsoft.Extensions.DependencyInjection;
using OrceiPdf.Application.Interfaces;
using OrceiPdf.Application.Services;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Repository.Repository;
using OrceiPdf.Repository.UoW;

namespace OrceiPdf.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
            services.AddScoped<IOrcamentoItemRepository, OrcamentoItemRepository>();

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IOrcamentoService, OrcamentoService>();
            services.AddScoped<IOrcamentoItemService, OrcamentoItemService>();
        }
    }
}
