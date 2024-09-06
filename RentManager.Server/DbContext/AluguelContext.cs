using Microsoft.EntityFrameworkCore;
using RentManager.Server.Models;

public class AluguelContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Imovel> Imoveis { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }

    public AluguelContext(DbContextOptions<AluguelContext> options)
        : base(options)
    {
    }
}
