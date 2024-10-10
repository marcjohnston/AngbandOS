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

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; } = null!;
        public virtual DbSet<Key> Keys { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; } = null!;
        public virtual DbSet<RepositoryEntity> RepositoryEntities { get; set; } = null!;
        public virtual DbSet<SavedGame> SavedGames { get; set; } = null!;
        public virtual DbSet<SavedGameContent> SavedGameContents { get; set; } = null!;
        public virtual DbSet<UserGameConfiguration> UserGameConfigurations { get; set; } = null!;
        public virtual DbSet<UserSetting> UserSettings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<DeviceCode>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode")
                    .IsUnique();

                entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DeviceCode1)
                    .HasMaxLength(200)
                    .HasColumnName("DeviceCode");

                entity.Property(e => e.SessionId).HasMaxLength(100);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Key>(entity =>
            {
                entity.HasIndex(e => e.Use, "IX_Keys_Use");

                entity.Property(e => e.Algorithm).HasMaxLength(100);

                entity.Property(e => e.IsX509certificate).HasColumnName("IsX509Certificate");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.FromUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.GameId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.SentDateTime).HasColumnType("datetime");

                entity.Property(e => e.ToUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.MessageFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_AspNetUsers");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.MessageToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .HasConstraintName("FK_Messages_AspNetUsers1");
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.ConsumedTime, "IX_PersistedGrants_ConsumedTime");

                entity.HasIndex(e => e.Expiration, "IX_PersistedGrants_Expiration");

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type }, "IX_PersistedGrants_SubjectId_ClientId_Type");

                entity.HasIndex(e => new { e.SubjectId, e.SessionId, e.Type }, "IX_PersistedGrants_SubjectId_SessionId_Type");

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.SessionId).HasMaxLength(100);

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<RepositoryEntity>(entity =>
            {
                entity.HasKey(e => new { e.RepositoryName, e.Key })
                    .HasName("PK_RepositoryEntities_1");

                entity.Property(e => e.RepositoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JsonData).IsUnicode(false);
            });

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

                entity.HasOne(d => d.SavedGameContent)
                    .WithMany(p => p.SavedGames)
                    .HasForeignKey(d => d.SavedGameContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SavedGames_SavedGameContents");
            });

            modelBuilder.Entity<UserGameConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.Name, e.Username });

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JsonData).IsUnicode(false);
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.F10macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F10Macro");

                entity.Property(e => e.F11macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F11Macro");

                entity.Property(e => e.F12macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F12Macro");

                entity.Property(e => e.F1macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F1Macro");

                entity.Property(e => e.F2macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F2Macro");

                entity.Property(e => e.F3macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F3Macro");

                entity.Property(e => e.F4macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F4Macro");

                entity.Property(e => e.F5macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F5Macro");

                entity.Property(e => e.F6macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F6Macro");

                entity.Property(e => e.F7macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F7Macro");

                entity.Property(e => e.F8macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F8Macro");

                entity.Property(e => e.F9macro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F9Macro");

                entity.Property(e => e.FontName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
