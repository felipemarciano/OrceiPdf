using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Services
{
    public class OrcamentoService : BaseService<Orcamento>, IOrcamentoService
    {
        private readonly IOrcamentoRepository _orcamentoRepository;

        public OrcamentoService(IUnitOfWork unitOfWork, IAsyncRepository<Orcamento> repository, IOrcamentoRepository orcamentoRepository)
            : base(unitOfWork, repository)
        {
            _orcamentoRepository = orcamentoRepository;
        }

        public async Task<GridResult<Orcamento>> ListarAsync(Guid empresaId, DataTableViewModel param)
        {
            return await _orcamentoRepository.ListarAsync(empresaId, param);
        }
    }
}
