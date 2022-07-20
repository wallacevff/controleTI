using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Models;

namespace ControleTI.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public Usuario Usuario { set; get; }
        public List<Setor> Setores { get; set; }
        public List<Filial> Filiais { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<UsuarioLic> UsuarioLics { get; set; }

    }
}
