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

        public async Task Insert(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Usuario.Include(obj => obj.Setor).Include(obj => obj.Filial).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            bool temAlgum = await _context.Usuario.AnyAsync(x => x.Id == usuario.Id);
            if (!temAlgum)
            {
                return;
            }
            _context.Update(usuario);
            
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
