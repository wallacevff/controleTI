using ControleTI.Data;
using ControleTI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Services
{
    public class StatusService
    {
        private readonly ControleTIContext _context;

        public StatusService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Status>> Listar()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task Cadastrar(Status status)
        {
            await _context.Status.AddAsync(status);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Status status)
        {
            _context.Update(status);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Status status)
        {
            _context.Remove(status);
            await _context.SaveChangesAsync();
        }

        public async Task<Status> FindByIdAsync(int id)
        {
            return await _context.Status.FirstOrDefaultAsync(
                obj => obj.StatusId == id
            );
        }

    }
}
