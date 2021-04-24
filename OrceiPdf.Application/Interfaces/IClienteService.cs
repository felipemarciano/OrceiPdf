using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Interfaces
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task<Cliente> GetbyUserId(Guid userId);
        Task<GridResult<Cliente>> ListarAsync(Guid userId, DataTableViewModel param);
    }
}
