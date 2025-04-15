using Microsoft.AspNetCore.Mvc;
using BarbeariaWeb.Areas.Identity.Models;

namespace BarbeariaWeb.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            UsuariosModel model = new();
            model.listUsuarios = UsuariosModel.tUsuarios_GET();
            return View(model);
        }
    }
}
