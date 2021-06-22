using Microsoft.AspNetCore.Mvc;
using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrceiPdf.Web.ViewComponents
{
    public class OrcamentoPdfViewComponent : ViewComponent
    {
        private readonly IOrcamentoService _orcamentoService;

        public OrcamentoPdfViewComponent(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var orcamento = await _orcamentoService.GetFromPdf(id);

            return View(orcamento);
        }
    }
}
