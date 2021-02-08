using System;
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

        public Dispositivo(int id, string nome, string macAdress)
        {
            Id = id;
            Nome = nome;
            MacAdress = macAdress;
        }

        public Dispositivo() { }
    }

}
