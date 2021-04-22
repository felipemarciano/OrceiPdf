using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Services
{
    public class EmpresaService : BaseService<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IUnitOfWork unitOfWork, IAsyncRepository<Empresa> repository, IEmpresaRepository empresaRepository)
            : base(unitOfWork, repository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<Empresa> GetbyUserId(Guid userId)
        {
            return await _empresaRepository.GetbyUserId(userId);
        }
    }
}
