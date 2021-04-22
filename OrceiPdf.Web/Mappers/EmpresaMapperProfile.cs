using AutoMapper;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Models;

namespace OrceiPdf.Web.Mappers
{
    public class EmpresaMapperProfile : Profile
    {
        public EmpresaMapperProfile()
        {
            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<Empresa, EmpresaViewModel>();
        }
    }
}
