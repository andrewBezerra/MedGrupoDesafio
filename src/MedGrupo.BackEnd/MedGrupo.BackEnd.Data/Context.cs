using MedGrupo.BackEnd.Core.Entities;
using MedGrupo.BackEnd.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MedGrupo.BackEnd.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMapper());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
