namespace BarbeariaWeb.Areas.Identity.Models
{
    public class EstiloCorteModel
    {
        public List<EstiloCorteModel> estiloCorteList { get; set; }
        public int cId { get; set; }
        public int cIdBarbearia { get; set; }
        public int cIdBarbeiro { get; set; }
        public string rNomeBarbeiro { get; set; }
        public string rTipoCorte { get; set; }
        public int cDuracao { get; set; }
    }
}
