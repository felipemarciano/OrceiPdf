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
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;
        private readonly IEmpresaService _empresaService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService, IEmpresaService empresaService)
        { 
            _logger = logger;
            _clienteService = clienteService;
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
            var cliente =
                await _clienteService.GetByIdAsync(id);

            await ConfiguraTela();

            if (cliente is null) {
                cliente = new() {
                    UserId = Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value)
                };
            }

            return View(cliente.ToClienteViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(ClienteViewModel model)
        {
            await ConfiguraTela();

            if (ModelState.IsValid) {
                try {

                    if (model.Id == Guid.Empty) {
                        await _clienteService.Add(model.ToCliente());
                    }
                    else {
                        _clienteService.Update(model.ToCliente());
                    }

                    TempData["MessagemOk"] = "Ação realizada com sucesso.";

                    return RedirectPermanent("cliente");
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

            var retorno = await _clienteService
                                .ListarAsync(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value), param);

            return Json(new {
                param.sEcho,
                iTotalRecords = retorno.CountTotal,
                iTotalDisplayRecords = retorno.List.Count(),
                aaData = retorno.List.Select(x => new[]
                {
                    x.Id.ToString(),
                    x.NomeFantasia,
                    x.RazaoSocial,
                    x.Email,
                    x.Celular
                }).ToList()
            });
        }
    }
}
