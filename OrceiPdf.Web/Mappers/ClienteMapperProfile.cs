using AutoMapper;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Models;

namespace OrceiPdf.Web.Mappers
{
    public class ClienteMapperProfile : Profile
    {
        public ClienteMapperProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
