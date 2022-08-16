using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class AngbandOSContext : DbContext
    {
        public AngbandOSContext()
        {
        }

        public AngbandOSContext(DbContextOptions<AngbandOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SavedGame> SavedGames { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavedGame>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Username });

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CharacterName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
