using AutoMapper;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Models;

namespace OrceiPdf.Web.Mappers
{
    public static class ProdutoMappers
    {
        internal static IMapper Mapper { get; }

        static ProdutoMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProdutoMapperProfile>())
                .CreateMapper();
        }

        public static Produto ToProduto(this ProdutoViewModel produtoViewModel)
        {
            return Mapper.Map<Produto>(produtoViewModel);
        }

        public static ProdutoViewModel ToProdutoViewModel(this Produto produto)
        {
            return Mapper.Map<ProdutoViewModel>(produto);
        }
    }
}
