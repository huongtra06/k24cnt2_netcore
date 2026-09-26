using Microsoft.EntityFrameworkCore;

namespace LHT2410900076_exam.Models;

public partial class LHTEmployees2410900076Context : DbContext
{
    public LHTEmployees2410900076Context()
    {
    }

    public LHTEmployees2410900076Context(
        DbContextOptions<LHTEmployees2410900076Context> options)
        : base(options)
    {
    }

    public virtual DbSet<LHTEmployees> LHTEmployees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LHTEmployees>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("LHTEmployee");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.LHTName)
                .HasMaxLength(100);

            entity.Property(e => e.LHTGender)
                .HasMaxLength(10);

            entity.Property(e => e.LHTEmail)
                .HasMaxLength(150);

            entity.Property(e => e.LHTPhone)
                .HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}