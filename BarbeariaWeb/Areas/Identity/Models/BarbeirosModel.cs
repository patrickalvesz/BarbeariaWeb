using Microsoft.AspNetCore.Mvc.Rendering;

namespace BarbeariaWeb.Areas.Identity.Models
{
    public class BarbeirosModel
    {
        public int cId { get; set; }
        public int cIdBarbearia { get; set; }
        public string rStr { get; set; }
        public SelectList comboBarberios { get; set; }
    }
}
