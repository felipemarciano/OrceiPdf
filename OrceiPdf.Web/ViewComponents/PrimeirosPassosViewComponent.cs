using Microsoft.AspNetCore.Mvc;
using OrceiPdf.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrceiPdf.Web.ViewComponents
{
    public class PrimeirosPassosViewComponent : ViewComponent
    {
        private readonly IEmpresaService _empresaService;
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;

        public PrimeirosPassosViewComponent( IEmpresaService empresaService, IClienteService clienteService, IProdutoService produtoService)
        {
            _empresaService = empresaService;
            _clienteService = clienteService;
            _produtoService = produtoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid userId)
        {
            var empresa =
                await _empresaService.GetbyUserId(userId);

            ViewBag.HasEmpresa = empresa != null;

            var cliente =
                await _clienteService.GetbyUserId(userId);

            ViewBag.HasCliente = cliente != null;

            var produto =
                await _produtoService.GetbyUserId(userId);

            ViewBag.HasProduto = produto != null;

            return View();
        }
    }
}
