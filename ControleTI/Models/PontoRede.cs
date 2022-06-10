using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleTI.Models
{
    public class PontoRede
    {
        public int Id { get; set; }
        public int FilialId { get; set; }
        public Filial Filial { get; set; }
        public int SetorId { get; set; }
        public Setor Setor { get; set; }
        [Display(Name = "Filial")]
        public string Funcao { get; set; }
        public virtual List<Ramal> Ramais { get; set; }
    }

}
