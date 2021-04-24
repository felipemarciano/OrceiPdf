using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Domain.Interfaces
{
    public interface IOrcamentoRepository : IAsyncRepository<Orcamento>
    {
        Task<GridResult<Orcamento>> ListarAsync(Guid empresaId, DataTableViewModel param);
    }
}
