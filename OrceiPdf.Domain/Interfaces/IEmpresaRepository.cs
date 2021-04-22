using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Domain.Interfaces
{
    public interface IEmpresaRepository : IAsyncRepository<Empresa>
    {
        Task<Empresa> GetbyUserId(Guid userId);
    }
}
