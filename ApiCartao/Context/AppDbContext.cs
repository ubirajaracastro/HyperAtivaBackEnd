using BackEndCadastro.Mapping;
using BackEndCadastro.Models;
using MeuRH.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BackEndCadastro.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }  



        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        { }
        public DbSet<Usuario> tblUsuario { get; set; }
        public DbSet<CartaoHeader> tblCartao { get; set; }
        public DbSet<CartaoDetail> tblCartaoDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CartaoHeaderMap());
            modelBuilder.ApplyConfiguration(new CartaoDetailMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=desenv;Database=hyperativa;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }


    }
}
