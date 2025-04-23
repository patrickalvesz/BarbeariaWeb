using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;

namespace BarbeariaWeb.Areas.Identity.Models
{
    public class ClsCombo
    {
        public int cId { get; set; }
        public string rStr { get; set; }
        //private static readonly string connectionString = "Server=tcp:osfedido.database.windows.net,1433;Initial Catalog=BD_Barbearia;Persist Security Info=False;User ID=dev;Password=0105Goncalves;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static readonly string connectionString = "Server=maglev.proxy.rlwy.net;Port=53555;Database=railway;Uid=root;Pwd=RVwCUAcVqrHrbcFyRVNabDHvcfJikatE;";


        public static SelectList ObterComboGenerico(string procName, Dictionary<string, object> parametros = null)
        {
            SelectList ret = null;
            try
            {
                IEnumerable<ClsCombo> listCombos;

                MySqlConnection con = new MySqlConnection(connectionString);
                DynamicParameters p = new DynamicParameters();
                con = new MySqlConnection(connectionString);

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
