using Microsoft.EntityFrameworkCore;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using OrceiPdf.Repository.Utils;
using System.Collections.Generic;

namespace OrceiPdf.Repository.Repository
{
    public class OrcamentoItemRepository : Repository<OrcamentoItem>, IOrcamentoItemRepository
    {
        public OrcamentoItemRepository(OrceiPdfDbContext context) : base(context)
        {
        }

        public void RemoveRange(ICollection<OrcamentoItem> orcamentoItems)
        {
            Context.OrcamentoItens.RemoveRange(orcamentoItems);
        }        
        
        public void RemoveRange(Guid orcamentoId)
        {
            Context.OrcamentoItens.RemoveRange(Context.OrcamentoItens.Where(a => a.OrcamentoId == orcamentoId).ToArray());
        }

        public void AddRange(ICollection<OrcamentoItem> orcamentoItems)
        {
            Context.OrcamentoItens.AddRange(orcamentoItems);
        }

        public async Task<GridResult<OrcamentoItem>> ListarAsync(Guid empresaId, DataTableViewModel param)
        {
            var query = Context.OrcamentoItens.Include(x => x.Orcamento)
            .Where(x => x.Orcamento.EmpresaId == empresaId && EF.Functions.Like(x.Produto.Descricao, $"%{param.sSearch}%"));

            var count = await query.CountAsync();

            if (!string.IsNullOrEmpty(param.sSortColumnName))
                query = query.OrderByDynamic(param.sSortColumnName, param.sSortDir_0.Contains("asc"));

            var list = await query.AsNoTracking().Skip(param.iDisplayStart).Take(param.iDisplayLength)
                .Select(x => x)
                .ToListAsync();

            return new GridResult<OrcamentoItem> { List = list, CountTotal = count };
        }
    }
}
