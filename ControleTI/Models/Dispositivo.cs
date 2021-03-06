﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Endereço MAC")]
        public string MacAdress { get; set; }
        public int TipoDispositivoId { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public virtual ICollection<DispositivoSoftware> DispositivosSoftwares { get; set; }

        public Dispositivo(int id, string nome, string macAdress, int idTipo)
        {
            Id = id;
            Nome = nome;
            MacAdress = macAdress;
            TipoDispositivoId = idTipo;
        }

        public Dispositivo()
        {
            DispositivosSoftwares = new HashSet<DispositivoSoftware>();
        }
    }

}
