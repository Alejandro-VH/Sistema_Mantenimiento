using Microsoft.EntityFrameworkCore;

public class MantencionDbContext : DbContext
{

    public MantencionDbContext()
    {
    }
    
    public MantencionDbContext(DbContextOptions<MantencionDbContext> options)
        : base(options)
    {
    }

    public DbSet<Camioneta> Camionetas { get; set; }
    public DbSet<HistorialMantencion> Historial { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camioneta>()
            .HasIndex(c => c.Patente)
            .IsUnique();

        modelBuilder.Entity<Camioneta>()
            .Property(c => c.Estado)
            .HasMaxLength(20);

        modelBuilder.Entity<HistorialMantencion>()
            .Property(h => h.Accion)
            .HasMaxLength(50);
    }
}
