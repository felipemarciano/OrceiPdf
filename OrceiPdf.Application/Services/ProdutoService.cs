using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Services
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IUnitOfWork unitOfWork, IAsyncRepository<Produto> repository, IProdutoRepository produtoRepository)
            : base(unitOfWork, repository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> GetbyUserId(Guid userId)
        {
            return await _produtoRepository.GetbyUserId(userId);
        }

        public async Task<GridResult<Produto>> ListarAsync(Guid userId, DataTableViewModel param)
        {
            return await _produtoRepository.ListarAsync(userId, param);
        }
    }
}
