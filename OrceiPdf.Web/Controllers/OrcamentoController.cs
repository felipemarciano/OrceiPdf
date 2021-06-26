using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrceiPdf.Application.Interfaces;
using OrceiPdf.Domain.Models;
using OrceiPdf.Web.Extensions;
using OrceiPdf.Web.Mappers;
using OrceiPdf.Web.Models;
using OrceiPdf.Web.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace OrceiPdf.Web.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly ILogger<OrcamentoController> _logger;
        private readonly IOrcamentoService _orcamentoService;
        private readonly IProdutoService _produtoService;
        private readonly IClienteService _clienteService;
        private readonly IEmpresaService _empresaService;
        private readonly IGeneratePdf _generatePdf;
        private readonly RenderViewComponentService _renderViewComponentService;

        public OrcamentoController(ILogger<OrcamentoController> logger, IOrcamentoService orcamentoService,
            IProdutoService produtoService, IClienteService clienteService, IEmpresaService empresaService, IGeneratePdf generatePdf,
            RenderViewComponentService renderViewComponentService)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _empresaService = empresaService;
            _generatePdf = generatePdf;
            _renderViewComponentService = renderViewComponentService;
        }

        public async Task ConfigurarTela()
        {
            var listClients = await _clienteService.ListarAsync(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value),
               new DataTableViewModel { iDisplayStart = 0, iDisplayLength = int.MaxValue }
               );

            ViewBag.ListCliente = listClients.List.ToDictionary(x => x.Id, x => x.NomeFantasia);
        }

        async Task ConfiguraTela()
        {
            var empresa =
            await _empresaService.GetbyUserId(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value));

            ViewBag.HasEmpresa = empresa != null;
        }

        public async Task<IActionResult> IndexAsync(Guid id)
        {
            await ConfigurarTela();

            var empresa =
                await _empresaService.GetbyUserId(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value));

            var userId = Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value);

            var orcamento =
                await _orcamentoService.GetbyUserId(userId, id);

            if (orcamento is null) {
                orcamento = new() {
                    Id = Guid.NewGuid(),
                    DataValidade = DateTime.Now.AddMonths(1),
                    EmpresaId = empresa.Id
                };
            }

            return View(orcamento.ToOrcamentoViewModel());
        }

        public async Task<IActionResult> ListAsync()
        {
            await ConfiguraTela();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(OrcamentoViewModel model)
        {
            await ConfigurarTela();

            if (ModelState.IsValid) {

                try {

                    await _orcamentoService.AddOrUpdate(model.ToOrcamento());

                    TempData["MessagemOk"] = "Ação realizada com sucesso.";

                    return RedirectPermanent("orcamento/list");
                }
                catch (Exception ex) {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> PdfAsync(Guid id)
        {
            var options = new ConvertOptions {
                PageSize = Wkhtmltopdf.NetCore.Options.Size.A4,
                PageMargins = new Wkhtmltopdf.NetCore.Options.Margins(0, 0, 0, 0)
            };

            _generatePdf.SetConvertOptions(options);

            var html = await _renderViewComponentService
                .RenderViewComponentToStringAsync<OrcamentoPdfViewComponent>(id);

            return File(_generatePdf.GetPDF(html), System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        public async Task<IActionResult> GetGrid(DataTableViewModel param)
        {
            GridResult<Orcamento> retorno = new() { CountTotal = 0, List = new List<Orcamento>() };

            var empresa =
                 await _empresaService.GetbyUserId(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value));

            if (empresa != null)
                retorno = await _orcamentoService
                                    .ListarAsync(empresa.Id, param);

            return Json(new {
                param.sEcho,
                iTotalRecords = retorno.CountTotal,
                iTotalDisplayRecords = retorno.List.Count(),
                aaData = retorno.List.Select(x => new[]
                {
                    x.Id.ToString(),
                    x.Numero.ToString().PadLeft(8, '0'),
                    x.Cliente.NomeFantasia,
                    x.Status.ToString(),
                }).ToList()
            });
        }
    }
}
