using Microsoft.EntityFrameworkCore;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrceiPdf.Repository.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(OrceiPdfDbContext context) : base(context)
        {
        }

        public async Task<Empresa> GetbyUserId(Guid userId)
        {
            return await Context.Empresas.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
