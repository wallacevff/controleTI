using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTI.Models;

namespace ControleTI.Data
{
    public class ControleTIContext : DbContext
    {
        public ControleTIContext (DbContextOptions<ControleTIContext> options)
            : base(options)
        {
        }

        public DbSet<ControleTI.Models.Filial> Filial { get; set; }
        public DbSet<ControleTI.Models.Setor> Setor { get; set; }
    }
}
