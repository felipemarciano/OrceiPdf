using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Services
{
    public class OrcamentoItemService : BaseService<OrcamentoItem>, IOrcamentoItemService
    {
        private readonly IOrcamentoItemRepository _orcamentoItemRepository;

        public OrcamentoItemService(IUnitOfWork unitOfWork, IAsyncRepository<OrcamentoItem> repository, IOrcamentoItemRepository orcamentoItemRepository)
            : base(unitOfWork, repository)
        {
            _orcamentoItemRepository = orcamentoItemRepository;
        }

        public async Task<GridResult<OrcamentoItem>> ListarAsync(Guid empresaId, DataTableViewModel param)
        {
            return await _orcamentoItemRepository.ListarAsync(empresaId, param);
        }
    }
}
