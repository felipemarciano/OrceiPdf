using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Interfaces
{
    public interface IOrcamentoItemService : IBaseService<OrcamentoItem>
    {
        Task<GridResult<OrcamentoItem>> ListarAsync(Guid empresaId, DataTableViewModel param);
    }
}
