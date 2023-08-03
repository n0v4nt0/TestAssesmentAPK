using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestToko.Models
{
    public partial class LoUserContext : DbContext
    {
        public LoUserContext()
        {
        }

        public LoUserContext(DbContextOptions<LoUserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoUser> LoUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Products__B40CC6CD73B27013");

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false); ;
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}