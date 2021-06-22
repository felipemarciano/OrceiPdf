using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Mappers;
using OrceiPdf.Web.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrceiPdf.Web.Controllers
{
    public class OrcamentoItemController : Controller
    {
        private readonly ILogger<OrcamentoItemController> _logger;
        private readonly IOrcamentoItemService _orcamentoItemService;

        public OrcamentoItemController(ILogger<OrcamentoItemController> logger, IOrcamentoItemService orcamentoItemService)
        {
            _logger = logger;
            _orcamentoItemService = orcamentoItemService;
        }

        public IActionResult List()
        {
            return View();
        }

        public async Task<IActionResult> GetGrid(DataTableViewModel param)
        {
            var numeroPagina = (param.iDisplayStart / param.iDisplayLength) + 1;

            var retorno = await _orcamentoItemService
                                .ListarAsync(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value), param);

            return Json(new {
                param.sEcho,
                iTotalRecords = retorno.CountTotal,
                iTotalDisplayRecords = retorno.List.Count(),
                aaData = retorno.List.Select(x => new[]
                {
                    x.Id.ToString(),
                    x.Descricao,
                    x.Quantidade.ToString("N2"),
                    x.ValorUnitario.ToString("N2")
                }).ToList()
            });
        }
    }
}
