
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTI.Models
{
    [Table("software")]
    public class Software
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<SerialKey> Keys { get; set; }
        public virtual ICollection<DispositivoSoftware> DispositivosSoftwares { get; set; }
        public Software(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Software()
        {
            DispositivosSoftwares = new HashSet<DispositivoSoftware>();
        }
    }
}
