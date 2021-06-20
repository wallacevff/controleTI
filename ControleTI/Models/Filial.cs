using System.ComponentModel.DataAnnotations;

namespace ControleTI.Models
{
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
