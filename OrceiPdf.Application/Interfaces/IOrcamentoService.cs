using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Interfaces
{
    public interface IOrcamentoService : IBaseService<Orcamento>
    {
        Task<GridResult<Orcamento>> ListarAsync(Guid empresaId, DataTableViewModel param);

        Task<Orcamento> GetbyUserId(Guid userId, Guid Id);
        Task AddOrUpdate(Orcamento orcamento);
        Task<Orcamento> GetFromPdf(Guid Id);
    }
}
