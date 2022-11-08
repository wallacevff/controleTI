using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTI.Models
{
    [Table("empresaparceira")]
    public class EmpresaParceira
    {
        public int Id { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public ICollection<Contrato> Contratos { get; set; }

        public EmpresaParceira()
        {
            Contratos = new List<Contrato>();
        }

    }
}
