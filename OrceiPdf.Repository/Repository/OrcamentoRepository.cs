using Microsoft.EntityFrameworkCore;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using OrceiPdf.Repository.Utils;

namespace OrceiPdf.Repository.Repository
{
    public class OrcamentoRepository : Repository<Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(OrceiPdfDbContext context) : base(context)
        {
        }

        public async Task<GridResult<Orcamento>> ListarAsync(Guid empresaId, DataTableViewModel param)
        {
            var query = Context.Orcamentos
            .Where(x => x.EmpresaId == empresaId && EF.Functions.Like(x.Numero.ToString(), $"%{param.sSearch}%"));

            var count = await query.CountAsync();

            if (!string.IsNullOrEmpty(param.sSortColumnName))
                query = query.OrderByDynamic(param.sSortColumnName, param.sSortDir_0.Contains("asc"));

            var list = await query.AsNoTracking().Skip(param.iDisplayStart).Take(param.iDisplayLength)
                .Select(x => x)
                .ToListAsync();

            return new GridResult<Orcamento> { List = list, CountTotal = count };
        }
    }
}
