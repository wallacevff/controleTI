using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class Software
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<SerialKey> Keys { get; set; }

        public Software(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Software(){ }
    }
}
