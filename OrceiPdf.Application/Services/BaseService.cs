using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Services
{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IAsyncRepository<TEntity> _repository;

        public BaseService(IUnitOfWork unitOfWork, IAsyncRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _repository.Add(entity); 
            await _unitOfWork.CommitAsync();
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _repository.Update(entity);
            _unitOfWork.CommitAsync().ConfigureAwait(false);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.CommitAsync().ConfigureAwait(false);
        }

        public async ValueTask<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
