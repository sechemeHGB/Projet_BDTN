using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projet_BDTN.Models;

namespace Projet_BDTN.Data
{
    public class Projet_BDTNContext : DbContext
    {
        public Projet_BDTNContext (DbContextOptions<Projet_BDTNContext> options)
            : base(options)
        {
        }

        public DbSet<Projet_BDTN.Models.cnsl>? Cnsl { get; set; }

        public DbSet<Projet_BDTN.Models.Vente>? Vente { get; set; }
    }
}
