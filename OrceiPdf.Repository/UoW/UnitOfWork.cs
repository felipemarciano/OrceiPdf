using OrceiPdf.Domain.Interfaces;
using OrceiPdf.Repository.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrceiPdf.Repository.UoW
{

    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly OrceiPdfDbContext _context;

        public UnitOfWork(OrceiPdfDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
