using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeUsu { get; set; }
        public string NomeCompleto { get; set; }
        public Filial Filial { get; set; }
        //public int FilialId { get; set; }
        //public int SetorId { get; set; }
        public Setor Setor { get; set; }
        public List<Dispositivo> Dispositivo { get; set; }

        public Usuario(int id, string nomeUsu, string nomeCompleto, Filial filial, Setor setor)
        {
            Id = id;
            NomeUsu = nomeUsu;
            NomeCompleto = nomeCompleto;
            Filial = filial;
            Setor = setor;
        }

        public Usuario() { }
    }
}
