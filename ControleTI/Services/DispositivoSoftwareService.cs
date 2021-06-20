using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using ControleTI.Models;



namespace ControleTI.Services
{
    public class DispositivoSoftwareService
    {
        private readonly ControleTIContext _context;

        public DispositivoSoftwareService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<DispositivoSoftware>> FindAllAsync()
        {
            return await _context.DispositivoSoftware
                .Include(obj => obj.Dispositivo)
                .Include(obj => obj.Software)
                .Include(obj => obj.SerialKey)
                .ToListAsync();
        }

        public async Task<List<DispositivoSoftware>> FindAllByIdAsync(int id)
        {
            return await _context.DispositivoSoftware.Where(obj => obj.DispositivoId == id)
                .Include(obj => obj.Dispositivo)
                .Include(obj => obj.Software)
                .Include(obj => obj.SerialKey)                
                .ToListAsync();
        }

        public async Task UpdateAsync(DispositivoSoftware dispositivoSoftware)
        {
            bool temAlgum = await _context.DispositivoSoftware.AnyAsync(x => x.Id == dispositivoSoftware.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(dispositivoSoftware);
            await _context.SaveChangesAsync();
        }

        public async Task<DispositivoSoftware> FindByIdAsync(int id)
        {
            return await _context.DispositivoSoftware
                .Include(obj => obj.Dispositivo)
                .Include(obj => obj.Software)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CriarAssync(DispositivoSoftware dispositivoSoftware)
        {
            await _context.DispositivoSoftware.AddAsync(dispositivoSoftware);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(DispositivoSoftware dispositivoSoftware)
        {
            _context.DispositivoSoftware.Remove(dispositivoSoftware);
            await _context.SaveChangesAsync();
        }


    }
}
