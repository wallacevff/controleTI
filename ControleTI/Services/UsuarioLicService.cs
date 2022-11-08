/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Models;
using ControleTI.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleTI.Services
{
    public class UsuarioLicService
    {
        private readonly ControleTIContext _context;

        public UsuarioLicService(ControleTIContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioLic>> FindAllAsync()
        {
            return await _context.UsuarioLic
                .ToListAsync();
        }

    }
}
*/