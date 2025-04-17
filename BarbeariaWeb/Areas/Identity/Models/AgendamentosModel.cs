using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;
namespace BarbeariaWeb.Areas.Identity.Models
{
    public class AgendamentosModel
    {
        public List<AgendamentosModel> agendamentosList { get; set; }
        public int cId { get; set; }
        public int cIdBarbearia { get; set; }
        public string rNome { get; set; }
        public string cTelefone { get; set; }
        public string rEmail { get; set; }
        public int cIdBarbeiro { get; set; }
        public int cProduto { get; set; }
        public DateTime dtInicio { get; set; }
        public DateTime dtFim { get; set; }
        public DateTime dtCriacao { get; set; }
    }
}
