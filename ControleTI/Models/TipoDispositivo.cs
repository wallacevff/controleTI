
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ControleTI.Models
{
    [Table("tipodispositivo")]
    public class TipoDispositivo
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Dispositivo> Dispositivos { get; set; }

        public TipoDispositivo(int id, string tipo)
        {
            Id = id;
            Tipo = tipo;
        }

        public TipoDispositivo(){ }
    }
}
