using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngbandOS.PersistentStorage.MySql.Entities
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

        public virtual DbSet<Aspnetrole> Aspnetroles { get; set; } = null!;
        public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; } = null!;
        public virtual DbSet<Aspnetuser> Aspnetusers { get; set; } = null!;
        public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; } = null!;
        public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; } = null!;
        public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; } = null!;
        public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; } = null!;
        public virtual DbSet<Devicecode> Devicecodes { get; set; } = null!;
        public virtual DbSet<Key> Keys { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Persistedgrant> Persistedgrants { get; set; } = null!;
        public virtual DbSet<Savedgame> Savedgames { get; set; } = null!;
        public virtual DbSet<Savedgamecontent> Savedgamecontents { get; set; } = null!;
        public virtual DbSet<Usersetting> Usersettings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetrole>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetroleclaim>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetuser>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasMaxLength(6);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetuserclaim>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).HasMaxLength(36);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(36);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserrole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserRoles_UserId");

                entity.Property(e => e.UserId).HasMaxLength(36);

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasMaxLength(36);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Devicecode>(entity =>
            {
                entity.HasKey(e => e.UserCode)
                    .HasName("PRIMARY");

                entity.ToTable("devicecodes");

                entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode")
                    .IsUnique();

                entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(200);

                entity.Property(e => e.CreationTime).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DeviceCode1)
                    .HasMaxLength(200)
                    .HasColumnName("DeviceCode");

                entity.Property(e => e.Expiration).HasMaxLength(6);

                entity.Property(e => e.SessionId).HasMaxLength(100);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Key>(entity =>
            {
                entity.ToTable("keys");

                entity.HasIndex(e => e.Use, "IX_Keys_Use");

                entity.Property(e => e.Algorithm).HasMaxLength(100);

                entity.Property(e => e.Created).HasMaxLength(6);

                entity.Property(e => e.IsX509certificate).HasColumnName("IsX509Certificate");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.HasIndex(e => e.FromUserId, "IX_Messages_FromUserId");

                entity.HasIndex(e => e.ToUserId, "IX_Messages_ToUserId");

                entity.Property(e => e.FromUserId).HasMaxLength(36);

                entity.Property(e => e.GameId).HasMaxLength(36);

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.SentDateTime).HasColumnType("datetime");

                entity.Property(e => e.ToUserId).HasMaxLength(36);

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

            modelBuilder.Entity<Persistedgrant>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("persistedgrants");

                entity.HasIndex(e => e.ConsumedTime, "IX_PersistedGrants_ConsumedTime");

                entity.HasIndex(e => e.Expiration, "IX_PersistedGrants_Expiration");

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type }, "IX_PersistedGrants_SubjectId_ClientId_Type");

                entity.HasIndex(e => new { e.SubjectId, e.SessionId, e.Type }, "IX_PersistedGrants_SubjectId_SessionId_Type");

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(200);

                entity.Property(e => e.ConsumedTime).HasMaxLength(6);

                entity.Property(e => e.CreationTime).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Expiration).HasMaxLength(6);

                entity.Property(e => e.SessionId).HasMaxLength(100);

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Savedgame>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Username })
                    .HasName("PRIMARY");

                entity.ToTable("savedgames");

                entity.HasIndex(e => e.SavedGameContentId, "IX_SavedGames_SavedGameContentId");

                entity.Property(e => e.CharacterName).HasMaxLength(255);

                entity.Property(e => e.Comments).HasMaxLength(1024);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SavedGameContent)
                    .WithMany(p => p.Savedgames)
                    .HasForeignKey(d => d.SavedGameContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SavedGames_SavedGameContents");
            });

            modelBuilder.Entity<Savedgamecontent>(entity =>
            {
                entity.ToTable("savedgamecontents");
            });

            modelBuilder.Entity<Usersetting>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("usersettings");

                entity.Property(e => e.UserId).HasMaxLength(36);

                entity.Property(e => e.F10macro)
                    .HasMaxLength(10)
                    .HasColumnName("F10Macro");

                entity.Property(e => e.F11macro)
                    .HasMaxLength(10)
                    .HasColumnName("F11Macro");

                entity.Property(e => e.F12macro)
                    .HasMaxLength(10)
                    .HasColumnName("F12Macro");

                entity.Property(e => e.F1macro)
                    .HasMaxLength(10)
                    .HasColumnName("F1Macro");

                entity.Property(e => e.F2macro)
                    .HasMaxLength(10)
                    .HasColumnName("F2Macro");

                entity.Property(e => e.F3macro)
                    .HasMaxLength(10)
                    .HasColumnName("F3Macro");

                entity.Property(e => e.F4macro)
                    .HasMaxLength(10)
                    .HasColumnName("F4Macro");

                entity.Property(e => e.F5macro)
                    .HasMaxLength(10)
                    .HasColumnName("F5Macro");

                entity.Property(e => e.F6macro)
                    .HasMaxLength(10)
                    .HasColumnName("F6Macro");

                entity.Property(e => e.F7macro)
                    .HasMaxLength(10)
                    .HasColumnName("F7Macro");

                entity.Property(e => e.F8macro)
                    .HasMaxLength(10)
                    .HasColumnName("F8Macro");

                entity.Property(e => e.F9macro)
                    .HasMaxLength(10)
                    .HasColumnName("F9Macro");

                entity.Property(e => e.FontName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
