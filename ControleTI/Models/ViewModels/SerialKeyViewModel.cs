using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Models;

namespace ControleTI.Models.ViewModels
{
    public class SerialKeyViewModel
    {
        public SerialKey SerialKey { get; set; }
        public Software Software { get; set; }
        public List<Software> Softwares { get; set; }
    
        public SerialKeyViewModel()
        {

        }
    }
  
}
