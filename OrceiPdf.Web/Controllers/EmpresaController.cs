using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrceiPdf.Application.Interfaces;
using OrceiPdf.Web.Mappers;
using OrceiPdf.Web.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrceiPdf.Web.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ILogger<EmpresaController> _logger;
        private readonly IEmpresaService _empresaService;

        public EmpresaController(ILogger<EmpresaController> logger, IEmpresaService empresaService)
        {
            _logger = logger;
            _empresaService = empresaService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var empresa =
                await _empresaService.GetbyUserId(Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value));

            if (empresa is null) {
                empresa = new() {
                    UserId = Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value)
                };
            }

            return View(empresa.ToEmpresaViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(EmpresaViewModel model)
        {
            if (ModelState.IsValid) {
                try {

                    if (model.Id == Guid.Empty) {
                        await _empresaService.Add(model.ToEmpresa());
                    }
                    else {
                        _empresaService.Update(model.ToEmpresa());
                    }

                    TempData["MessagemOk"] = "Ação realizada com sucesso.";

                    return RedirectPermanent("empresa");
                }
                catch (Exception ex) {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }
    }
}
