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
            return await _context.Usuario
                .Include(obj => obj.Setor)
                .Include(x => x.Filial)
                .OrderBy(x => x.NomeUsu)
                .ToListAsync();
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

        public async Task<List<Usuario>> FindByNameAsync(string name)
        {
            return await _context.Usuario
                .Where(obj => obj.NomeUsu.ToLower().Contains(name.ToLower()))
                .Include(obj => obj.Setor)
                .Include(obj => obj.Filial)
                .ToListAsync();
        }

        public async Task<List<Usuario>> PesquisarNomeCompleto(string name)
        {
            return await _context.Usuario
                .Where(obj => obj.NomeCompleto.ToLower().Contains(name.ToLower()))
                .Include(obj => obj.Setor)
                .Include(obj => obj.Filial)
                .ToListAsync();
        }

        public async Task<List<Usuario>> PesquisarSetor(int setorId)
        {
            return await _context.Usuario
                .Where(obj => obj.SetorId == setorId)
                .Include(obj => obj.Setor)
                .Include(obj => obj.Filial)
                .ToListAsync();
        }

        public async Task<List<Usuario>> PesquisarFilial(int filialId)
        {
            return await _context.Usuario
                .Where(obj => obj.FilialId == filialId)
                .Include(obj => obj.Setor)
                .Include(obj => obj.Filial)
                .ToListAsync();
        }

        public async Task<List<UsuarioLic>> ListarUsuarioLic()
        {
            return await _context.UsuarioLic
                .OrderBy(o => o.Usuario)
                .ToListAsync();
        }
    }
}
