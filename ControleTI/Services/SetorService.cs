using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using ControleTI.Models;



namespace ControleTI.Services
{
    public class SetorService
    {
        private readonly ControleTIContext _context;

        public SetorService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<Setor>> FindAllAsync()
        {
            return await _context.Setor.ToListAsync();
        }

        public async Task UpdateAsync(Setor setor)
        {
            bool temAlgum = await _context.Setor.AnyAsync(x => x.Id == setor.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(setor);
            await _context.SaveChangesAsync();
        }

        public async Task<Setor> FindByIdAsync(int id)
        {
            return await _context.Setor.Include(obj => obj.Usuarios).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CriarAssync(Setor setor)
        {
            await _context.Setor.AddAsync(setor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Setor setor)
        {
            _context.Setor.Remove(setor);
            await _context.SaveChangesAsync();
        }

    }
}
