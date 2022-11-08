using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ControleTI.Models
{
    [Table("setor")]
    public class Setor
    {
        public int Id { get; set; }
        [Display(Name = "Setor")]
        public string Nome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

        public Setor(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Setor() { }
    }
}
