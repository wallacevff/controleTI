using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using ControleTI.Models;


namespace ControleTI.Services
{
    public class PontoRedeService
    {
        private readonly ControleTIContext _context;

        public PontoRedeService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<PontoRede>> ListAll()
        {
            return await _context.PontoRede.ToListAsync();
        }

        public async Task Add(PontoRede ponto)
        {
            await _context.PontoRede.AddAsync(ponto);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task Update(PontoRede ponto)
        {
            bool temAlgum = await _context.PontoRede.AnyAsync(x => x.Id == ponto.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(ponto);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
