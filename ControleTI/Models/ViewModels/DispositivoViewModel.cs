﻿using System.Collections.Generic;
using ControleTI.Models;
using System.Linq;
namespace ControleTI.Models.ViewModels
{
    public class DispositivoViewModel
    {
        public List<Dispositivo> Dispositivos { get; set; }
        public Dispositivo Dispositivo { set; get; }
        public List<TipoDispositivo> TiposDispositivos { get; set; }
        public List<Status> Status { get; set; }
        public List<Usuario> Usuarios { set; get; }
    }
}
