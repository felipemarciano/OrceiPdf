using Microsoft.AspNetCore.Mvc;
using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrceiPdf.Web.ViewComponents
{
    public class DropdownViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Dictionary<Guid, string> list, string htmlName,
            Guid codigo, bool? isSelect2 = true, bool isRequired = false, bool hasFirstValue = true, bool orderByDesc = false)
        {
            ViewBag.HtmlName = htmlName;
            ViewBag.Codigo = codigo;
            ViewBag.IsSelect2 = isSelect2;
            ViewBag.IsRequired = isRequired;
            ViewBag.HasFirstValue = hasFirstValue;

            if (orderByDesc)
                return View(list?.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value));
            else
                return View(list?.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value));
        }
    }
}
