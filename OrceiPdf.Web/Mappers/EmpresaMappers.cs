using AutoMapper;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Models;

namespace OrceiPdf.Web.Mappers
{
    public static class EmpresaMappers
    {
        internal static IMapper Mapper { get; }

        static EmpresaMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<EmpresaMapperProfile>())
                .CreateMapper();
        }

        public static Empresa ToEmpresa(this EmpresaViewModel empresaViewModel)
        {
            return Mapper.Map<Empresa>(empresaViewModel);
        }

        public static EmpresaViewModel ToEmpresaViewModel(this Empresa empresa)
        {
            return Mapper.Map<EmpresaViewModel>(empresa);
        }
    }
}
