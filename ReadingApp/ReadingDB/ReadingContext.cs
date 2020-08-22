using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReadingDB
{
    public partial class ReadingContext : DbContext
    {
        public ReadingContext()
        {
        }

        public ReadingContext(DbContextOptions<ReadingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reading> Reading { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=Reading;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reading>(entity =>
            {
                entity.Property(e => e.ReadingAuthor).HasMaxLength(50);

                entity.Property(e => e.ReadingModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReadingNotes).HasMaxLength(1000);

                entity.Property(e => e.ReadingTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReadingType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
