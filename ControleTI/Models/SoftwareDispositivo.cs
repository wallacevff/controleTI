using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class SoftwareDispositivo
    {
        public Dispositivo Dispositivo { get; set; }
        public Software Software { get; set; }        

        public SoftwareDispositivo(Dispositivo dispositivo, Software software)
        {
            Dispositivo = dispositivo;
            Software = software;            
        }

    }
}
