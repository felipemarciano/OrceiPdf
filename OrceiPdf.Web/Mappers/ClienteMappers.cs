using AutoMapper;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Models;

namespace OrceiPdf.Web.Mappers
{
    public static class ClienteMappers
    {
        internal static IMapper Mapper { get; }

        static ClienteMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClienteMapperProfile>())
                .CreateMapper();
        }

        public static Cliente ToCliente(this ClienteViewModel clienteViewModel)
        {
            return Mapper.Map<Cliente>(clienteViewModel);
        }

        public static ClienteViewModel ToClienteViewModel(this Cliente cliente)
        {
            return Mapper.Map<ClienteViewModel>(cliente);
        }
    }
}
