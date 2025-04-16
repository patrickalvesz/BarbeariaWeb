using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;
namespace BarbeariaWeb.Areas.Identity.Models
{
    public class GestaoModel
    {
        public List<GestaoModel> listUsuarios { get; set; }
        public int cId { get; set; }
        public int cIdLoja { get; set; }
        public string rNome { get; set; }
        public string cTelefone { get; set; }
        public string rEmail { get; set; }
        public int cIdEmpregado { get; set; }
        public int cProduto { get; set; }
        public DateTime dtInicio { get; set; }
        public DateTime dtFim { get; set; }
        public DateTime dtCriacao { get; set; }
        public SelectList comboEstadoCivil { get; set; }

        private static readonly string connectionString = "Server=tcp:osfedido.database.windows.net,1433;Initial Catalog=BD_Barbearia;Persist Security Info=False;User ID=dev;Password=0105Goncalves;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static List<GestaoModel> tUsuarios_GET()
        {
            List<GestaoModel> listUsuarios = new();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    listUsuarios = conn.Query<GestaoModel>("pAgendamentos_GET", commandType: CommandType.StoredProcedure).ToList();
                }

                return listUsuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return listUsuarios;
            }
        }

    }
    public class ClsCombo
    {
        public string cId { get; set; }
        public string rStr { get; set; }
        private static readonly string connectionString = "Server=tcp:osfedido.database.windows.net,1433;Initial Catalog=BD_Barbearia;Persist Security Info=False;User ID=dev;Password=0105Goncalves;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SelectList tCombo_GET(string operacao)
        {
            SelectList ret = null;
            IEnumerable<ClsCombo> listCombos;

            SqlConnection con = new SqlConnection(connectionString);
            DynamicParameters p = new DynamicParameters();
            p.Add("@OPERACAO", operacao);
            con = new SqlConnection(connectionString);

            listCombos = con.Query<ClsCombo>("pCombo_GET", p, commandType: System.Data.CommandType.StoredProcedure).ToList();

            ret = new SelectList(listCombos, "cId", "rStr");

            return ret;
        }
    }
}
