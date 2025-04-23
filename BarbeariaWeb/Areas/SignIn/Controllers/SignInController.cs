using BarbeariaWeb.Areas.Identity.Models;
using BarbeariaWeb.Areas.SignIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarbeariaWeb.Areas.SignIn.Controllers
{
    [Area("SignIn")]
    public class SignInController : Controller
    {
        private static readonly string connectionString = "Server=maglev.proxy.rlwy.net;Port=53555;Database=railway;Uid=root;Pwd=RVwCUAcVqrHrbcFyRVNabDHvcfJikatE;";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(string email, string password)
        {
            GestaoModel.ExecutarProcGenerica(connectionString, "pUsuarios_POST", new Dictionary<string, object> { { "rEmailSelecionado", email },
                                                                                                                  { "rPsswSelecionado", CriptoUtils.Criptografar(password) } });


            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AutenticarUsuario(string email, string password)
        {
            try
            {
                UsuariosModel verificaEmailSenha = GestaoModel.ObterListaGenerica<UsuariosModel>(connectionString, "pUsuarios_GET").FirstOrDefault(x => x.rEmail == email && x.rPssw == CriptoUtils.Criptografar(password));

                if (verificaEmailSenha != null)
                {
                    TempData["success"] = "E-mail e senha corretos.";
                    return View("Index");
                }
                else
                {
                    TempData["erro"] = "E-mail ou senha invalidos.";
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                TempData["erro"] = "E-mail ou senha invalidos.";
                return View("Index");
            }

        }

    }
}
