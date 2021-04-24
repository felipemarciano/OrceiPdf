using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Domain.Interfaces
{
    public interface IClienteRepository : IAsyncRepository<Cliente>
    {
        Task<Cliente> GetbyUserId(Guid userId);
        Task<GridResult<Cliente>> ListarAsync(Guid userId, DataTableViewModel param);
    }
}
