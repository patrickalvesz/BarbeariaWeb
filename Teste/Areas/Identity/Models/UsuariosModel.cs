using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;
namespace Teste.Areas.Identity.Models
{
    public class UsuariosModel
    {
        public List<UsuariosModel> listUsuarios { get; set; }
        public int cId { get; set; }
        public string rNome { get; set; }
        public long cCpf { get; set; }
        public long cTelefone { get; set; }
        public string dtNascimento { get; set; }
        public int pinto { get; set; }
        public int cComboEstadoCivil { get; set; }

        public SelectList comboEstadoCivil { get; set; }

        private static readonly string connectionString = "Server=PATRICK\\SQLEXPRESS;Database=BD_COTACAO;Integrated Security=True;";

        public static List<UsuariosModel> tUsuarios_GET()
        {
            List<UsuariosModel> listUsuarios = new();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    listUsuarios = conn.Query<UsuariosModel>("tUsuarios_GET", commandType: CommandType.StoredProcedure).ToList();
                }

                return listUsuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return listUsuarios;
            }
        }

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
    public class ClsCombo
    {
        public string cId { get; set; }
        public string rStr { get; set; }
    }
}
