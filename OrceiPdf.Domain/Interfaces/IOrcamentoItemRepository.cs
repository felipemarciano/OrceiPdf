using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrceiPdf.Domain.Interfaces
{
    public interface IOrcamentoItemRepository : IAsyncRepository<OrcamentoItem>
    {
        Task<GridResult<OrcamentoItem>> ListarAsync(Guid empresaId, DataTableViewModel param);
        void RemoveRange(ICollection<OrcamentoItem> orcamentoItems);
        void AddRange(ICollection<OrcamentoItem> orcamentoItems);
        void RemoveRange(Guid orcamentoId);
    }
}
