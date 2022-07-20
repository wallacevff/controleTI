using System.ComponentModel.DataAnnotations;


namespace ControleTI.Models
{
    public class UsuarioLic
    {
        public string Id { get; set; }
        [Display(Name = "Nome de usuário")]
        public string Usuario { get; set; }
        public string Dispositivo { get; set; }
        public string Software { get; set; }


        public UsuarioLic() { }
    }
}
