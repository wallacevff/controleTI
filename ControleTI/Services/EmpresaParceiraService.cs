﻿using ControleTI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ControleTI.Services
{
    public class EmpresaParceiraService
    {
        private readonly ControleTI.Data.ControleTIContext _context;

        public EmpresaParceiraService(ControleTI.Data.ControleTIContext context)
        {
            _context = context;
        }

        public async Task<EmpresaParceira> AddEmpresaParceira(EmpresaParceira empresaParceira)
        {
            var emp = await _context
                .EmpresaParceira
                .AddAsync(empresaParceira);
            _context.SaveChanges();
            
            return emp.Entity;
        }

        public async Task<IEnumerable<EmpresaParceira>> ListEmpresaParceira()
        {
            return await _context
                .EmpresaParceira
                .ToListAsync();
        }

        public async Task DeleteEmpresaParceira(EmpresaParceira empresaParceira)
        {
            _context.Remove(empresaParceira);
            await _context.SaveChangesAsync();
        }

        public async Task<EmpresaParceira> FindEmpresaParceiraById(int id)
        {
            return await _context.EmpresaParceira.FindAsync(id);
        }

        public async Task UpdateEmpresaParceira(EmpresaParceira e)
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
