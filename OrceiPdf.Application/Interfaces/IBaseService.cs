using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(Guid id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
