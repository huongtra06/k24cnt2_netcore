using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LHTLesson10EFDBFirst.Models;

public partial class Lhtlesson10EfdbContext : DbContext
{
    public Lhtlesson10EfdbContext()
    {
    }

    public Lhtlesson10EfdbContext(DbContextOptions<Lhtlesson10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lhtmember> Lhtmembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LHTLesson10EFDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lhtmember>(entity =>
        {
            entity.ToTable("LHTMember");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Lhtemail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LHTEmail");
            entity.Property(e => e.Lhtpassword)
                .HasMaxLength(50)
                .HasColumnName("LHTPassword");
            entity.Property(e => e.Lhtphone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LHTPhone");
            entity.Property(e => e.Lhtstatus).HasColumnName("LHTStatus");
            entity.Property(e => e.Lhtusername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LHTUsername");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
