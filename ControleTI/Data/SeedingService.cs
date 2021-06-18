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
            Setor s11 = new Setor(11, "Programação Técnica");

            Filial f1 = new Filial(1, "Matriz");
            Filial f2 = new Filial(2, "Rio das Ostras");
            Filial f3 = new Filial(3, "Salvador");
            Filial f4 = new Filial(4, "Belém");
            Filial f5 = new Filial(5, "São Luiz");
            Filial f6 = new Filial(6, "Manaus");

            Usuario u1 = new Usuario(1, "wallace.vidal", "Wallace Vidal de Figueiredo Fortuna", f1, s10);
            Usuario u2 = new Usuario(2, "sara.lisboa", "Sara Lisboa Dias", f1, s3);
            Usuario u3 = new Usuario(3, "erica.santos", "Erica Santos", f1, s1);
            Usuario u4 = new Usuario(4, "jardel.leite", "Francisco Jardel Leite", f1, s10);
            Usuario u5 = new Usuario(5, "lais.veiga", "Lais Canella Veiga", f1, s7);
            Usuario u6 = new Usuario(6, "eldine.oliveira", "Eldine Sanches Oliveira", f4, s11);

            TipoDispositivo td1 = new TipoDispositivo(1, "Desktop");
            TipoDispositivo td2 = new TipoDispositivo(2, "Notebook");
            TipoDispositivo td3 = new TipoDispositivo(3, "AllInOne");
            TipoDispositivo td4 = new TipoDispositivo(4, "Multifuncional");

            _context.Setor.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11);
            _context.Filial.AddRange(f1, f2, f3, f4, f5, f6);
            _context.Usuario.AddRange(u1, u2, u3, u4, u5, u6);
            _context.SaveChanges();
        }
    }
}
