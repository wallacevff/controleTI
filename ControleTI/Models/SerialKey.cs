﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTI.Models
{
    [Table("serialkey")]
    public class SerialKey
    {
        //[Key, Column(Order = 0)]
        public int Id { get; set; }
        public int SoftwareId { get; set; }
       // [Key, Column(Order = 1)]
        public String Key { get; set; }
        [Display(Name = "Id de Instalação")]
        // public String IdInstalacao { get; set; }
        public Software Software { get; set; }
        public int Quantidade { get; set; }
        public int Utilizadas { get; set; }
        public int Restantes { get; set; }
        public virtual List<DispositivoSoftware> DispositivosSoftwares { get; set;}

        public void RestantesInicial()
        {
            Restantes = Quantidade;
        }

        public void RestantesAtualizar()
        {
            Restantes = Quantidade - Utilizadas;
        }

        public void UtilizadasIncrementar()
        {
            Utilizadas++;
            RestantesAtualizar();
        }

        public void UtilizadasDecrementar()
        {
            Utilizadas--;
            RestantesAtualizar();
        }

        public SerialKey(string key, Software software)
        {
            Key = key;
            Software = software;
        }

        public SerialKey() { }

        

    }
}
