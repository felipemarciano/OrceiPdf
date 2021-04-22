using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrceiPdf.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();

        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
