using Microsoft.AspNetCore.Mvc;
using BarbeariaWeb.Areas.Identity.Models;

namespace BarbeariaWeb.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class GestaoController : Controller
    {
        public IActionResult Index()
        {
            GestaoModel model = new();
            model.listUsuarios = GestaoModel.tUsuarios_GET();
            return View(model);
        }
    }
}
