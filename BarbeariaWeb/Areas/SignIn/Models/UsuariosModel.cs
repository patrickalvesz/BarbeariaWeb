namespace BarbeariaWeb.Areas.SignIn.Models
{
    public class UsuariosModel
    {
        public List<UsuariosModel> usuariosList { get; set; }
        public int cId { get; set; }
        public string rEmail { get; set; }
        public string rPssw { get; set; }
        public string rRefreshToken { get; set; }
    }
}
