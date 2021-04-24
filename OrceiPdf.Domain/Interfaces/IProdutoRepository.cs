using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Domain.Interfaces
{
    public interface IProdutoRepository : IAsyncRepository<Produto>
    {
        Task<Produto> GetbyUserId(Guid userId);
        Task<GridResult<Produto>> ListarAsync(Guid userId, DataTableViewModel param);
    }
}
