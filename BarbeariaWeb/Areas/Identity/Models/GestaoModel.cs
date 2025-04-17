using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Data;

namespace BarbeariaWeb.Areas.Identity.Models
{
    public class GestaoModel
    {
        public AgendamentosModel AgendamentosModel { get; set; }
        public BarbeirosModel BarbeirosModel { get; set; }
        public EstiloCorteModel EstiloCorteModel { get; set; }

        public GestaoModel()
        {
            AgendamentosModel = new AgendamentosModel();
            BarbeirosModel = new BarbeirosModel();
            EstiloCorteModel = new EstiloCorteModel();
        }



        public static List<T> ObterListaGenerica<T>(string connectionString, string procName, Dictionary<string, object> parametros = null)
        {
            List<T> resultado = new();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var p = new DynamicParameters();

                    if (parametros != null)
                    {
                        foreach (var item in parametros)
                        {
                            p.Add(item.Key, item.Value);
                        }
                    }

                    resultado = conn.Query<T>(procName, p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }

        public static bool ExecutarProcGenerica(string connectionString, string procName, Dictionary<string, object> parametros = null)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var p = new DynamicParameters();

                    if (parametros != null)
                    {
                        foreach (var item in parametros)
                        {
                            p.Add(item.Key, item.Value);
                        }
                    }

                    conn.Query(procName, p, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }

}
