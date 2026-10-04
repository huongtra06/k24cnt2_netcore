using LHTLesson14.Models;
using Microsoft.EntityFrameworkCore;

namespace LHTLesson14.Data;

public class LHTLesson14Context : DbContext
{
    public LHTLesson14Context(DbContextOptions<LHTLesson14Context> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Banner> Banners => Set<Banner>();
    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(e =>
        {
            e.ToTable("CATEGORY");
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(100).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
            e.Property(x => x.Status).HasDefaultValue((byte)1);
            e.Property(x => x.CreatedDate).HasDefaultValueSql("CAST(GETDATE() AS date)");
            e.Property(x => x.Image).HasMaxLength(255);
            e.Property(x => x.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Product>(e =>
        {
            e.ToTable("PRODUCT");
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(100).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
            e.Property(x => x.Price).HasColumnType("decimal(18,2)");
            e.Property(x => x.SalePrice).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            e.Property(x => x.Status).HasDefaultValue((byte)1);
            e.Property(x => x.CreatedDate).HasDefaultValueSql("CAST(GETDATE() AS date)");
            e.Property(x => x.Image).HasMaxLength(255);
            e.Property(x => x.Description).HasMaxLength(500);
            e.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Banner>(e =>
        {
            e.ToTable("BANNER");
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(100).IsRequired();
            e.Property(x => x.Status).HasDefaultValue((byte)1);
            e.Property(x => x.Priority).HasDefaultValue(0);
            e.Property(x => x.Image).HasMaxLength(255);
            e.Property(x => x.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Blog>(e =>
        {
            e.ToTable("BLOG");
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(150).IsRequired();
            e.Property(x => x.Status).HasDefaultValue((byte)1);
            e.Property(x => x.CreatedDate).HasDefaultValueSql("CAST(GETDATE() AS date)");
            e.Property(x => x.Image).HasMaxLength(255);
            e.Property(x => x.Description).HasMaxLength(500);
        });
    }
}
