using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Models;

namespace ControleTI.Models.VewModels
{
    public class UsuarioViewModel
    {
        public Usuario Usuario { set; get; }
        public Setor Setor { get; set; }
        public Filial Filial { get; set; }
    }
}
