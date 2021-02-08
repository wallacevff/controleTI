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

        public async Task<List<Setor>> ListarTodos()
        {
            return await _context.Setor.ToListAsync();
        }

    }
}
