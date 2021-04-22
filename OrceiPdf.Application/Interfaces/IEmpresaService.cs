using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Interfaces
{
    public interface IEmpresaService : IBaseService<Empresa>
    {
        Task<Empresa> GetbyUserId(Guid userId);
    }
}
