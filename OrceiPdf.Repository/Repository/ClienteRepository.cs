using Microsoft.EntityFrameworkCore;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using OrceiPdf.Repository.Utils;

namespace OrceiPdf.Repository.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(OrceiPdfDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetbyUserId(Guid userId)
        {
            return await Context.Clientes.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<GridResult<Cliente>> ListarAsync(Guid userId, DataTableViewModel param)
        {
            var query = Context.Clientes
            .Where(x => x.UserId == userId && (EF.Functions.Like(x.NomeFantasia, $"%{param.sSearch}%") ||
                        EF.Functions.Like(x.Email, $"%{param.sSearch}%") ||
                        EF.Functions.Like(x.RazaoSocial, $"%{param.sSearch}%")));

            var count = await query.CountAsync();

            if (!string.IsNullOrEmpty(param.sSortColumnName))
                query = query.OrderByDynamic(param.sSortColumnName, param.sSortDir_0.Contains("asc"));

            var list = await query.AsNoTracking().Skip(param.iDisplayStart).Take(param.iDisplayLength)
                .Select(x => x)
                .ToListAsync();

            return new GridResult<Cliente> { List = list, CountTotal = count };
        }
    }
}
