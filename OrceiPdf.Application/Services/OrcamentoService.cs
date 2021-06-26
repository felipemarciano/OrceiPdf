using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Services
{
    public class OrcamentoService : BaseService<Orcamento>, IOrcamentoService
    {
        private readonly IOrcamentoRepository _orcamentoRepository;
        private readonly IOrcamentoItemRepository _orcamentoItemRepository;

        public OrcamentoService(IUnitOfWork unitOfWork, IAsyncRepository<Orcamento> repository, IOrcamentoRepository orcamentoRepository,
            IOrcamentoItemRepository orcamentoItemRepository)
            : base(unitOfWork, repository)
        {
            _orcamentoRepository = orcamentoRepository;
            _orcamentoItemRepository = orcamentoItemRepository;
        }

        public async Task<GridResult<Orcamento>> ListarAsync(Guid empresaId, DataTableViewModel param)
        {
            return await _orcamentoRepository.ListarAsync(empresaId, param);
        }

        public async Task AddOrUpdate(Orcamento orcamento)
        {
            var listUpdate = new List<OrcamentoItem>();

            foreach (var i in orcamento.OrcamentoItens)
            {
                i.OrcamentoId = orcamento.Id;
                i.CreatedDate = DateTime.Now;
                i.ModifiedDate = DateTime.Now;
                listUpdate.Add(i);
            }

            if (orcamento.Numero == 0)
            {
                orcamento.CreatedDate = DateTime.Now;
                orcamento.ModifiedDate = DateTime.Now;
                orcamento.Status = Domain.Enum.EOrcamentoStatus.Pendente;
                orcamento.OrcamentoItens = listUpdate;
                orcamento.Numero = _orcamentoRepository.GetLastNumber();

                await Add(orcamento);
            }
            else
            {
                orcamento.ModifiedDate = DateTime.Now;
                _orcamentoItemRepository.RemoveRange(orcamento.Id);
                _orcamentoItemRepository.AddRange(listUpdate);

                Update(orcamento);
            }
        }

        public async Task<Orcamento> GetbyUserId(Guid userId, Guid Id)
        {
            return await _orcamentoRepository.GetbyUserId(userId, Id);
        }

        public async Task<Orcamento> GetFromPdf(Guid Id)
        {
            return await _orcamentoRepository.GetFromPdf(Id);
        }
    }
}
