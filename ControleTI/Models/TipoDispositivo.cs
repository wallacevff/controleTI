using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class TipoDispositivo
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public TipoDispositivo(int id, string tipo)
        {
            Id = id;
            Tipo = tipo;
        }

        public TipoDispositivo(){ }
    }
}
