using Microsoft.EntityFrameworkCore;
using Sinqia.Calculator.Domain.Entities;

namespace Sinqia.Calculator.Infrastructure.DataAccess;

public class SinqiaCalculatorDbContext : DbContext
{
    public SinqiaCalculatorDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Cotacao> Cotacoes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SinqiaCalculatorDbContext).Assembly);
        
        modelBuilder.Entity<Cotacao>(entity =>
        {
            entity.ToTable("cotacao");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Data).IsRequired();
            entity.Property(e => e.Indexador).IsRequired().HasMaxLength(30);
            entity.Property(e => e.Valor).HasColumnType("decimal(10,2)").IsRequired();
        });
    }
}