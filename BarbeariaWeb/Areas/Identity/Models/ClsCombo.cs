using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace BarbeariaWeb.Areas.Identity.Models
{
    public class ClsCombo
    {
        public int cId { get; set; }
        public string rStr { get; set; }
        private static readonly string connectionString = "Server=tcp:osfedido.database.windows.net,1433;Initial Catalog=BD_Barbearia;Persist Security Info=False;User ID=dev;Password=0105Goncalves;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SelectList ObterComboGenerico(string procName, Dictionary<string, object> parametros = null)
        {
            SelectList ret = null;
            try
            {
                IEnumerable<ClsCombo> listCombos;

                SqlConnection con = new SqlConnection(connectionString);
                DynamicParameters p = new DynamicParameters();
                con = new SqlConnection(connectionString);

                if (parametros != null)
                {
                    foreach (var item in parametros)
                    {
                        p.Add(item.Key, item.Value);
                    }
                }

                listCombos = con.Query<ClsCombo>(procName, p, commandType: System.Data.CommandType.StoredProcedure).ToList();

                List<ClsCombo> listaFinal = new List<ClsCombo>
                {
                    new ClsCombo { cId = 0, rStr = "" }
                };
                listaFinal.AddRange(listCombos);

                ret = new SelectList(listaFinal, "cId", "rStr");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }
    }
}
