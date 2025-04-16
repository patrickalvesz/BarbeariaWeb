using Microsoft.AspNetCore.Mvc;

namespace BarbeariaWeb.Areas.SignIn.Controllers
{
    [Area("SignIn")]
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
