using ControleTI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ControleTI.Services
{
    public class ContratoService
    {
        private readonly ControleTI.Data.ControleTIContext _context;

        public ContratoService(ControleTI.Data.ControleTIContext context)
        {
            _context = context;
        }

        public async Task<Contrato> AddContrato(Contrato contrato)
        {
            var con = await _context
                .Contrato
                .AddAsync(contrato);
            _context.SaveChanges();
            
            return con.Entity;
        }

        public async Task<IEnumerable<Contrato>> ListContrato()
        {
            return await _context
                .Contrato
                .Include(o => o.EmpresaParceira)
                .ToListAsync();
        }

        public async Task DeleteContrato(Contrato contrato)
        {
            _context.Remove(contrato);
            await _context.SaveChangesAsync();
        }

        public async Task<Contrato> FindContratoById(int id)
        {
            return await _context.Contrato
                .Include(o => o.EmpresaParceira)
                .FirstOrDefaultAsync(o => o.Id == id)
                ;
        }

        public async Task UpdateContrato(Contrato e)
        {
            bool temAlgum = await _context.EmpresaParceira.AnyAsync(obj => obj.Id == e.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(e);
            await _context.SaveChangesAsync();
        }
    }
}
