using Microsoft.AspNetCore.Mvc;
using OrceiPdf.Domain.Models;
using System.Collections.Generic;

namespace OrceiPdf.Web.ViewComponents
{
    public class OrcamentoItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<OrcamentoItem> list)
        {
            return View(list is null ? new List<OrcamentoItem>() : list);
        }
    }
}
