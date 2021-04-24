using Microsoft.EntityFrameworkCore;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using OrceiPdf.Repository.Utils;

namespace OrceiPdf.Repository.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(OrceiPdfDbContext context) : base(context)
        {
        }

        public async Task<Produto> GetbyUserId(Guid userId)
        {
            return await Context.Produtos.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<GridResult<Produto>> ListarAsync(Guid userId, DataTableViewModel param)
        {
            var query = Context.Produtos
            .Where(x => x.UserId == userId && EF.Functions.Like(x.Descricao, $"%{param.sSearch}%"));

            var count = await query.CountAsync();

            if (!string.IsNullOrEmpty(param.sSortColumnName))
                query = query.OrderByDynamic(param.sSortColumnName, param.sSortDir_0.Contains("asc"));

            var list = await query.AsNoTracking().Skip(param.iDisplayStart).Take(param.iDisplayLength)
                .Select(x => x)
                .ToListAsync();

            return new GridResult<Produto> { List = list, CountTotal = count };
        }
    }
}
