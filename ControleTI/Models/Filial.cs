using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTI.Models
{
    [Table("filial")]
    public class Filial
    {
        public int Id { get; set; }
        [Display(Name = "Filial")]
        public string Nome { get; set; }
        public Filial(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Filial() { }
    }

    
}
