using ControleTI.Data;
using ControleTI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace ControleTI.Services
{
    public class SoftwareService
    {
        private readonly ControleTIContext _context;

        public SoftwareService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<Software>> FindAllAsync()
        {
            return await _context.Software.ToListAsync();
        }

        public async Task UpdateAsync(Software software)
        {
            bool temAlgum = await _context.Software.AnyAsync(x => x.Id == software.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(software);
            await _context.SaveChangesAsync();
        }

        public async Task<Software> FindByIdAsync(int id)
        {
            return await _context.Software.Include(obj => obj.DispositivosSoftwares).ThenInclude(obj => obj.Dispositivo).Include(obj => obj.DispositivosSoftwares).ThenInclude(obj => obj.SerialKey).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CriarAssync(Software software)
        {
            await _context.Software.AddAsync(software);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Software software)
        {
            _context.Software.Remove(software);
            await _context.SaveChangesAsync();
        }


    }
}