using AutoMapper;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Models;

namespace OrceiPdf.Web.Mappers
{
    public static class OrcamentoMappers
    {
        internal static IMapper Mapper { get; }

        static OrcamentoMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<OrcamentoMapperProfile>())
                .CreateMapper();
        }

        public static Orcamento ToOrcamento(this OrcamentoViewModel orcamentoViewModel)
        {
            return Mapper.Map<Orcamento>(orcamentoViewModel);
        }

        public static OrcamentoViewModel ToOrcamentoViewModel(this Orcamento orcamento)
        {
            return Mapper.Map<OrcamentoViewModel>(orcamento);
        }
    }
}
