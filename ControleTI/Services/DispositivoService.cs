using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using ControleTI.Models;



namespace ControleTI.Services
{
    public class DispositivoService
    {
        private readonly ControleTIContext _context;

        public DispositivoService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<Dispositivo>> FindAllAsync()
        {
            return await _context.Dispositivo.Include(obj => obj.TipoDispositivo).Include(obj => obj.Usuario).ToListAsync();
        }

        public async Task UpdateAsync(Dispositivo dispositivo)
        {
            bool temAlgum = await _context.Dispositivo.AnyAsync(x => x.Id == dispositivo.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(dispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task<Dispositivo> FindByIdAsync(int id)
        {
            return await _context.Dispositivo
                .Include(obj => obj.TipoDispositivo)
                .Include(obj => obj.Usuario)
                .Include(obj => obj.DispositivosSoftwares).ThenInclude(obj => obj.Software)
                .Include(obj => obj.DispositivosSoftwares).ThenInclude(obj => obj.SerialKey)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CriarAssync(Dispositivo dispositivo)
        {
            await _context.Dispositivo.AddAsync(dispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Dispositivo dispositivo)
        {
            _context.Dispositivo.Remove(dispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dispositivo>> PesquisaNome(string pesquisa)
        {
            return await _context.Dispositivo.Where(d => d.Nome.ToLower().Contains(pesquisa.ToLower())).ToListAsync();
        }


    }
}
