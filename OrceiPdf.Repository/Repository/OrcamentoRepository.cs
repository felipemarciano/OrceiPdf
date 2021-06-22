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

        public async Task<Orcamento> GetbyUserId(Guid userId, Guid Id)
        {
            return await Context.Orcamentos.Include(x=> x.OrcamentoItens).ThenInclude(x => x.Produto)
                .FirstOrDefaultAsync(x => x.Empresa.UserId == userId && x.Id == Id);
        }

        public async Task<Orcamento> GetbyIdAsNoTranking(Guid Id)
        {
            return await Context.Orcamentos.AsNoTracking().Include(x => x.OrcamentoItens).ThenInclude(x => x.Produto)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Orcamento> GetFromPdf(Guid Id)
        {
            return await Context.Orcamentos.AsNoTracking()
                .Include(x => x.OrcamentoItens).ThenInclude(x => x.Produto)
                .Include(x => x.Cliente)
                .Include(x => x.Empresa)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public int GetLastNumber()
        {
            return Context.Orcamentos.Count() + 1;
        }

        public async Task<GridResult<Orcamento>> ListarAsync(Guid empresaId, DataTableViewModel param)
        {
            var query = Context.Orcamentos.Include(x => x.Cliente)
            .Where(x => x.EmpresaId == empresaId && 
                (EF.Functions.Like(x.Numero.ToString(), $"%{param.sSearch}%") || EF.Functions.Like(x.Cliente.NomeFantasia, $"%{param.sSearch}%")
                || EF.Functions.Like(x.Cliente.RazaoSocial, $"%{param.sSearch}%") || EF.Functions.Like(x.Cliente.Cnpj, $"%{param.sSearch}%")));

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
