using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestToko.Models
{
    public partial class BarangContext : DbContext
    {
        public BarangContext()
        {
        }

        public BarangContext(DbContextOptions<BarangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barang { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang)
                    .HasName("PK__Products__B40CC6CD73B27013");

                entity.Property(e => e.NamaBarang)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HargaBarang)
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.QtyBarang)
                    .HasColumnType("decimal(18, 1)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}