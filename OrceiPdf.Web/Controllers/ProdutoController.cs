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
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _produtoService;
        private readonly IEmpresaService _empresaService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService, IEmpresaService empresaService)
        {
            _logger = logger;
            _produtoService = produtoService;
            _empresaService = empresaService;
        }

        async Task ConfiguraTela()
        {
            var empresa =
            await _empresaService.GetbyUserId(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value));

            ViewBag.HasEmpresa = empresa != null;
        }

        public async Task<IActionResult> IndexAsync(Guid id)
        {
            var produto =
                await _produtoService.GetByIdAsync(id);

            await ConfiguraTela();

            if (produto is null) {
                produto = new() {
                    UserId = Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value)
                };
            }

            return View(produto.ToProdutoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(ProdutoViewModel model)
        {
            await ConfiguraTela();

            if (ModelState.IsValid) {
                try {

                    if (model.Id == Guid.Empty) {
                        await _produtoService.Add(model.ToProduto());
                    }
                    else {
                        _produtoService.Update(model.ToProduto());
                    }

                    TempData["MessagemOk"] = "Ação realizada com sucesso.";

                    return RedirectPermanent("produto");
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

            var retorno = await _produtoService
                                .ListarAsync(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value), param);

            return Json(new {
                param.sEcho,
                iTotalRecords = retorno.CountTotal,
                iTotalDisplayRecords = retorno.List.Count(),
                aaData = retorno.List.Select(x => new[]
                {
                    x.Id.ToString(),
                    x.Descricao,
                    x.ValorUnitario.ToString("N2")
                }).ToList()
            });
        }
    }
}
