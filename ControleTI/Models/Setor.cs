using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Setor(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Setor() { }
    }
}
