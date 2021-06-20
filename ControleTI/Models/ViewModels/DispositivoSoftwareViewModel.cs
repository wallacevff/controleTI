using System.Collections.Generic;
using ControleTI.Models;
namespace ControleTI.Models.ViewModels
{
    public class DispositivoSoftwareViewModel
    {
        public DispositivoSoftware DispositivoSoftware { get; set; }
        public Dispositivo Dispositivo { set; get; }
        public Software Software { get; set; }
        public Software SerialKey { get; set; }
        public List<Software> Softwares { get; set; }
        public List<SerialKey> SerialKeys { set; get; }
    }
}
