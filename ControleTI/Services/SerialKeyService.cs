using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using ControleTI.Models;



namespace ControleTI.Services
{
    public class SerialKeyService
    {
        private readonly ControleTIContext _context;

        public SerialKeyService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<SerialKey>> FindAllAsync()
        {
            return await _context.SerialKey.Include(obj => obj.Software).OrderBy(obj => obj.Software.Nome).ToListAsync();
        }

        public async Task UpdateAsync(SerialKey serialKey)
        {
            bool temAlgum = await _context.SerialKey.AnyAsync(x => x.Id == serialKey.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(serialKey);
            await _context.SaveChangesAsync();
        }

        public async Task<SerialKey> FindByIdAsync(int id)
        {
            return await _context.SerialKey.Include(obj => obj.Software).Include(obj => obj.DispositivosSoftwares).ThenInclude(obj => obj.Dispositivo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CriarAssync(SerialKey serialKey)
        {
            await _context.SerialKey.AddAsync(serialKey);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SerialKey serialKey)
        {
            _context.SerialKey.Remove(serialKey);
            await _context.SaveChangesAsync();
        }


    }
}
