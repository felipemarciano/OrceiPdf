using AutoMapper;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Models;

namespace OrceiPdf.Web.Mappers
{
    public class OrcamentoMapperProfile : Profile
    {
        public OrcamentoMapperProfile()
        {
            CreateMap<OrcamentoViewModel, Orcamento>();
            CreateMap<Orcamento, OrcamentoViewModel>();
        }
    }
}
