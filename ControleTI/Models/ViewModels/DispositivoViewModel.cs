using System.Collections.Generic;
using ControleTI.Models;
namespace ControleTI.Models.ViewModels
{
    public class DispositivoViewModel
    {
        public Dispositivo Dispositivo { set; get; }
        public List<TipoDispositivo> TiposDispositivos { get; set; }
        public List<Usuario> Usuarios { set; get; }
    }
}
