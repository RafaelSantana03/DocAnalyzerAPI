using Microsoft.EntityFrameworkCore;
using DocAnalyzerAPI.Models;


namespace DocAnalyzerAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Document> Documents => Set<Document>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(d => d.Id);

            entity.Property(d => d.FileName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(d => d.OriginalName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(d => d.Status)
                .HasConversion<string>(); // Salva o enum como string no banco para facilitar leitura e manutenção
        });
    }
}

