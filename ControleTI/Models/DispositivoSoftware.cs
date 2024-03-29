﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTI.Models
{
    [Table("dispositivosoftware")]
    public class DispositivoSoftware
    {
        public int Id { get; set; }
        public int DispositivoId { get; set; }
        public Dispositivo Dispositivo { get; set; }
        public int SoftwareId { get; set; }
        public Software Software { get; set; }
        public DispositivoSoftware() { }
        public int? SerialKeyId { get; set; }
        public SerialKey SerialKey { get; set; }
        public string IdInstalacao { get; set; }
        public DispositivoSoftware(int id, int dispositivoId, Dispositivo dispositivo, int softwareId, Software software)
        {
            Id = id;
            DispositivoId = dispositivoId;
            Dispositivo = dispositivo;
            SoftwareId = softwareId;
            Software = software;
        }
    }
}
