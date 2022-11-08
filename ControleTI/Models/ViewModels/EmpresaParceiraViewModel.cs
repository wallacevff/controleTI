using System.Collections.Generic;

namespace ControleTI.Models.ViewModels
{
    public class EmpresaParceiraViewModel
    {
        public IEnumerable<EmpresaParceira> EmpresasParceiras { get; set; }
        public EmpresaParceiraViewModel()
        {
            EmpresasParceiras = new List<EmpresaParceira>();
        }

        public EmpresaParceiraViewModel(IEnumerable<EmpresaParceira> empresaParceiras)
        {
            EmpresasParceiras = empresaParceiras;
        }
    }
}