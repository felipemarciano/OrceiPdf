using Microsoft.AspNetCore.Mvc;

namespace OrceiPdf.Web.ViewComponents
{
    public class ModalCrudViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
