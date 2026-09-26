using Microsoft.EntityFrameworkCore;

namespace LuongHuongTra2410900076_exam.Models;

public class Lht_2410900076Context : DbContext
{
    public Lht_2410900076Context(DbContextOptions<Lht_2410900076Context> options) : base(options)
    {
    }

    public DbSet<LhtEmployee> LhtEmployees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LhtEmployee>(entity =>
        {
            entity.ToTable("LhtEmployee");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LhtName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LhtGender).HasMaxLength(20);
            entity.Property(e => e.LhtEmail).HasMaxLength(150);
            entity.Property(e => e.LhtPhone).HasMaxLength(20);
            entity.Property(e => e.LhtActive).HasDefaultValue(true);
        });
    }
}
