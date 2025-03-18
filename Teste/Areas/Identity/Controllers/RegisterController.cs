using Microsoft.AspNetCore.Mvc;
using Teste.Areas.Identity.Models;

namespace Teste.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            UsuariosModel model = new();
            model.listUsuarios = UsuariosModel.tUsuarios_GET();
            model.comboEstadoCivil = UsuariosModel.tCombo_GET("ESCI");
            model.pinto = 17;
            return View(model);
        }
    }
}
