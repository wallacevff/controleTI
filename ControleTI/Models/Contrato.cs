using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTI.Models
{
    [Table("contrato")]
    public class Contrato
    {
        public int Id { get; set; }
        [Display(Name ="Descrição do Contrato")]
        public string Descricao { get; set; }
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int EmpresaParceiraId { get; set; }
        public EmpresaParceira EmpresaParceira { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
