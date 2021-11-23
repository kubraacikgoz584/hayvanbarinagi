 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarınagi.Models
{
    public class ApplicationDbContext : DbContext
    {  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalTypes> AnimalTypes { get; set; }
        public DbSet<GenderType> GenderType { get; set; }
        public DbSet<OwnedType> OwnedType { get; set; } 
    }
}
