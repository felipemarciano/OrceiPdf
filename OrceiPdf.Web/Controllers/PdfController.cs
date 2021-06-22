using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace OrceiPdf.Web.Controllers
{
    public class PdfController : Controller
    {
        readonly IGeneratePdf _generatePdf;

        private readonly ILogger<PdfController> _logger;

        public PdfController(ILogger<PdfController> logger, IGeneratePdf generatePdf)
        {
            _logger = logger;
            _generatePdf = generatePdf;
        }

        public IActionResult Get(string html)
        {
            var options = new ConvertOptions {
                PageSize = Wkhtmltopdf.NetCore.Options.Size.A4,
                PageMargins = new Wkhtmltopdf.NetCore.Options.Margins(0, 0, 0, 0)
            };

            _generatePdf.SetConvertOptions(options);

            return File(_generatePdf.GetPDF(html), System.Net.Mime.MediaTypeNames.Application.Pdf);
        }
    }
}
