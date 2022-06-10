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
                .ThenInclude(obj => obj.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SerialKey>> FindAllByIdAsync(int id)
        {
            return await _context.SerialKey
                .Where(obj => obj.SoftwareId == id && obj.Restantes > 0)
                .ToListAsync();
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

        public async Task<List<SerialKey>> PesquisaNome(string pesquisa)
        {
            return await _context.SerialKey
                .Include(obj => obj.Software)
                .Where(d => d.Key.ToLower().Contains(pesquisa.ToLower())).ToListAsync();
        }
        
        public async Task<List<SerialKey>> PesquisaSoftware(string pesquisa)
        {
            return await _context.SerialKey
                .Include(obj => obj.Software)
                .Where(d => d.Software.Nome.ToLower().Contains(pesquisa.ToLower())).ToListAsync();
        }

        public async Task<List<SerialKey>> Pesquisar(string serialKey, string software, bool? restantes)
        {
            List<SerialKey> serialKeys = null;
            if (!string.IsNullOrEmpty(serialKey))
            {
                serialKeys = await _context.SerialKey
                    .Include(obj => obj.Software)
                    .Where(d => d.Key.ToLower().Contains(serialKey.ToLower()))
                    .ToListAsync();
            }
            if (!string.IsNullOrEmpty(software))
            {
                if (serialKeys == null)
                {
                    serialKeys = await _context.SerialKey
                    .Include(obj => obj.Software)
                    .Where(d => d.Software.Nome.ToLower().Contains(software.ToLower()))
                    .ToListAsync();
                }
                else
                {
                    serialKeys = serialKeys
                        .Where(d => d.Software.Nome.ToLower().Contains(software.ToLower()))
                        .ToList();
                }

            }
            if (restantes != null)
            {
                if (serialKeys == null && restantes == true)
                {
                    serialKeys = await _context.SerialKey
                    .Include(obj => obj.Software)
                    .Where(d => d.Restantes > 0)
                    .ToListAsync();
                }
                if (serialKeys == null && restantes == false)
                {
                    serialKeys = await _context.SerialKey
                    .Include(obj => obj.Software)
                    .Where(d => d.Restantes == 0)
                    .ToListAsync();
                }
                if (serialKeys != null && restantes == true)
                {
                    serialKeys = serialKeys
                    .Where(d => d.Restantes > 0)
                    .ToList();
                }
                if (serialKeys != null && restantes == false)
                {
                    serialKeys = serialKeys
                    .Where(d => d.Restantes == 0)
                    .ToList();
                }
            }

            if (serialKeys == null)
            {
                serialKeys =  await _context
                    .SerialKey
                    .Include(obj => obj.Software)
                    .ToListAsync();
            }

            return serialKeys;
        }
    }
}
