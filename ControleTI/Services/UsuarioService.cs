using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Models;
using ControleTI.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleTI.Services
{
    public class UsuarioService
    {
        private readonly ControleTIContext _context;

        public UsuarioService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _context.Usuario.Include(obj => obj.Setor).OrderBy(x => x.NomeUsu).ToListAsync();
        }
    }
}
