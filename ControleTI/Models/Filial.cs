using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class Filial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Filial(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Filial() { }
    }

    
}
