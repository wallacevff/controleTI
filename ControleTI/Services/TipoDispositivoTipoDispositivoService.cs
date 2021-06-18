using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using ControleTI.Models;



namespace ControleTI.Services
{
    public class TipoDispositivoService
    {
        private readonly ControleTIContext _context;

        public TipoDispositivoService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<TipoDispositivo>> FindAllAsync()
        {
            return await _context.TipoDispositivo.ToListAsync();
        }

        public async Task UpdateAsync(TipoDispositivo tipoDispositivo )
        {
            bool temAlgum = await _context.TipoDispositivo.AnyAsync(x => x.Id == tipoDispositivo.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(tipoDispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoDispositivo> FindByIdAsync(int id)
        {
            return await _context.TipoDispositivo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CriarAssync(TipoDispositivo tipoDispositivo)
        {
            await _context.TipoDispositivo.AddAsync(tipoDispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TipoDispositivo tipoDispositivo)
        {
            _context.TipoDispositivo.Remove(tipoDispositivo);
            await _context.SaveChangesAsync();
        }


    }
}
