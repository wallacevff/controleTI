using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Models;

namespace ControleTI.Data
{
    public class SeedingService
    {
        private readonly ControleTIContext _context;

        public SeedingService(ControleTIContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Setor.Any() ||
                _context.Filial.Any())
            {
                return;
            }

            Setor s1 = new Setor(1, "Central de Atendimento ao Cliente");
            Setor s2 = new Setor(2, "Comercial");
            Setor s3 = new Setor(3, "Compras");
            Setor s4 = new Setor(4, "Laboratório");
            Setor s5 = new Setor(5, "Financeiro");
            Setor s6 = new Setor(6, "Logística");
            Setor s7 = new Setor(7, "Faturamento");
            Setor s8 = new Setor(8, "Contabilidade");
            Setor s9 = new Setor(9, "Departamento Pessoal");
            Setor s10 = new Setor(10, "Técnologia da Informação");

            Filial f1 = new Filial(1, "Matriz");
            Filial f2 = new Filial(2, "Rio das Ostras");
            Filial f3 = new Filial(3, "Salvador");
            Filial f4 = new Filial(4, "Belém");
            Filial f5 = new Filial(5, "São Luiz");
            Filial f6 = new Filial(6, "Manaus");

            _context.Setor.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10);
            _context.Filial.AddRange(f1, f2, f3, f4, f5, f6);
            _context.SaveChanges();
        }
    }
}
