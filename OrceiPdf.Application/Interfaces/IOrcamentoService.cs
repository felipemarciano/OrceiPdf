﻿using OrceiPdf.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Application.Interfaces
{
    public interface IOrcamentoService : IBaseService<Orcamento>
    {
        Task<GridResult<Orcamento>> ListarAsync(Guid empresaId, DataTableViewModel param);
    }
}