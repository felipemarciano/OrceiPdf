using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Interfaces
{
    public interface IProdutoService : IBaseService<Produto>
    {
        Task<Produto> GetbyUserId(Guid userId);
        Task<GridResult<Produto>> ListarAsync(Guid userId, DataTableViewModel param);
    }
}
