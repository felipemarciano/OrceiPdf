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
    public class OrcamentoController : Controller
    {
        private readonly ILogger<OrcamentoController> _logger;
        private readonly IOrcamentoService _orcamentoService;

        public OrcamentoController(ILogger<OrcamentoController> logger, IOrcamentoService orcamentoService)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
        }

        public async Task<IActionResult> IndexAsync(Guid id)
        {
            var orcamento =
                await _orcamentoService.GetByIdAsync(id);

            if (orcamento is null) {
                orcamento = new() {
                    UserId = Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value)
                };
            }

            return View(orcamento.ToOrcamentoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(OrcamentoViewModel model)
        {
            if (ModelState.IsValid) {
                try {

                    if (model.Id == Guid.Empty) {
                        await _orcamentoService.Add(model.ToOrcamento());
                    }
                    else {
                        _orcamentoService.Update(model.ToOrcamento());
                    }

                    TempData["MessagemOk"] = "Ação realizada com sucesso.";

                    return RedirectPermanent("orcamento");
                }
                catch (Exception ex) {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> GetGrid(DataTableViewModel param)
        {
            var numeroPagina = (param.iDisplayStart / param.iDisplayLength) + 1;

            var retorno = await _orcamentoService
                                .ListarAsync(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value), param);

            return Json(new {
                param.sEcho,
                iTotalRecords = retorno.CountTotal,
                iTotalDisplayRecords = retorno.List.Count(),
                aaData = retorno.List.Select(x => new[]
                {
                    x.Id.ToString(),
                    x.Descricao,
                    x.ValorUnitario.ToString()
                }).ToList()
            });
        }
    }
}
