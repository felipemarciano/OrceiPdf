using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IUnitOfWork unitOfWork, IAsyncRepository<Cliente> repository, IClienteRepository clienteRepository)
            : base(unitOfWork, repository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> GetbyUserId(Guid userId)
        {
            return await _clienteRepository.GetbyUserId(userId);
        }

        public async Task<GridResult<Cliente>> ListarAsync(Guid userId, DataTableViewModel param)
        {
            return await _clienteRepository.ListarAsync(userId, param);
        }
    }
}
