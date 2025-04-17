using Microsoft.AspNetCore.Mvc;
using BarbeariaWeb.Areas.Identity.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace BarbeariaWeb.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class GestaoController : Controller
    {
        private static readonly string connectionString = "Server=tcp:osfedido.database.windows.net,1433;Initial Catalog=BD_Barbearia;Persist Security Info=False;User ID=dev;Password=0105Goncalves;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public IActionResult Index()
        {
            GestaoModel model = new();
            model.AgendamentosModel.agendamentosList = GestaoModel.ObterListaGenerica<AgendamentosModel>(connectionString, "pAgendamentos_GET");
            model.BarbeirosModel.comboBarberios = ClsCombo.ObterComboGenerico("pBarbeiros_GET", new Dictionary<string, object> { { "@cIdBarbearia", 1 } });
            return View(model);
        }

        [HttpGet]
        public JsonResult ObterCortesBarbeiro(int cIdBarbeiro)
        {
            GestaoModel model = new();

            model.EstiloCorteModel.estiloCorteList = GestaoModel.ObterListaGenerica<EstiloCorteModel>(connectionString, "pEstiloCorte_GET", new Dictionary<string, object> { { "@cIdBarbeiro", cIdBarbeiro } });

            return Json(model.EstiloCorteModel.estiloCorteList);
        }

        [HttpDelete]
        public bool ExcluirCorteBarbeiro(int cId)
        {
            bool ret = false;
            try
            {
                ret = GestaoModel.ExecutarProcGenerica(connectionString, "pEstiloCorte_DEL", new Dictionary<string, object> { { "@cId", cId } });
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ret;
            }
        }
    }
}
