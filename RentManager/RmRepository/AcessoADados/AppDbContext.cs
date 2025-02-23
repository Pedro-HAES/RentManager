using Microsoft.EntityFrameworkCore;
using RmModel.Entidades;

namespace RmRepository.AcessoADados
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Casa> Casas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
       optionsBuilder.UseFirebird("User=SYSDBA;Password=masterkey;Database=localhost:D:\\Rent\\RENTMANAGER.FDB;Charset=NONE;Dialect=3;");

    }
}
