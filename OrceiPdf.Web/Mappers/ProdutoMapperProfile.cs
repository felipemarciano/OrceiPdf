using AutoMapper;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Models;

namespace OrceiPdf.Web.Mappers
{
    public class ProdutoMapperProfile : Profile
    {
        public ProdutoMapperProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}
