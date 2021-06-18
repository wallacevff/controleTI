
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTI.Models
{
    public class SoftwareDispositivo
    {
        [Key, Column(Order = 0)]
        public int DispositivoId { get; set; }
        [Key, Column(Order = 1)]
        public int SoftwareId { get; set; }
        public Dispositivo Dispositivo { get; set; }
        public Software Software { get; set; }

        public SoftwareDispositivo(Dispositivo dispositivo, Software software)
        {
            Dispositivo = dispositivo;
            Software = software;
        }
        public SoftwareDispositivo() { }

    }
}
