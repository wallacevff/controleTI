using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTI.Models
{
    [Table("usuariolic")]
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
