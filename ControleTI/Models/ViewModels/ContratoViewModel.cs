using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleTI.Models.ViewModels
{
    public class ContratoViewModel
    {
        [Display(Name = "Empresas Parceiras")]
        public IEnumerable<EmpresaParceira> EmpresasParceiras { get; set; }
        public IEnumerable<Contrato> Contratos { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
        
        public Contrato Contrato { get; set; }
        public ContratoViewModel()
        {
            EmpresasParceiras = new List<EmpresaParceira>();
        }

        public ContratoViewModel(IEnumerable<EmpresaParceira> empresaParceiras)
        {
            EmpresasParceiras = empresaParceiras;
        }

        public ContratoViewModel(IEnumerable<EmpresaParceira> empresaParceiras, Contrato contrato)
        {
            EmpresasParceiras = empresaParceiras;
            Contrato = contrato;
        }

        public ContratoViewModel(IEnumerable<EmpresaParceira> empresaParceiras, IEnumerable<Contrato> contratos)
        {
            EmpresasParceiras = empresaParceiras;
            Contratos = contratos;
        }
        public ContratoViewModel(
            IEnumerable<EmpresaParceira> empresaParceiras,
            IEnumerable<Contrato> contratos,
            IEnumerable<Usuario> usuarios)
        {
            EmpresasParceiras = empresaParceiras;
            Contratos = contratos;
            Usuarios = usuarios;
        }
        public ContratoViewModel(
            IEnumerable<EmpresaParceira> empresaParceiras,
            IEnumerable<Usuario> usuarios)
        {
            EmpresasParceiras = empresaParceiras;
            Usuarios = usuarios;
        }
        public ContratoViewModel(
          IEnumerable<EmpresaParceira> empresaParceiras,
          Contrato contrato,
          IEnumerable<Usuario> usuarios)
        {
            Contrato = contrato;
            EmpresasParceiras = empresaParceiras;
            Usuarios = usuarios;
        }
    }
}