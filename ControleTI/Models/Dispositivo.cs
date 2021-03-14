﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MacAdress { get; set; }
        public int IdTipo { get; set;}
        public TipoDispositivo tipoDispositivo { get; set; }

        public Dispositivo(int id, string nome, string macAdress, int idTipo)
        {
            Id = id;
            Nome = nome;
            MacAdress = macAdress;
            IdTipo = idTipo;
        }

        public Dispositivo() { }
    }

}
