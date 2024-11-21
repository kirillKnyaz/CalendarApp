using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CalendarApp.Models
{
    public partial class calendadbContext : DbContext
    {
        public calendadbContext()
        {
        }

        public calendadbContext(DbContextOptions<calendadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Recurrence> Recurrence { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:fsd12.database.windows.net,1433;Database=calendadb;User Id=dbadmin;Password=2@DC7dfjrtLxqrm;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__category__72E12F1B0B33983E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorCode)
                    .IsRequired()
                    .HasColumnName("color_code")
                    .HasMaxLength(7);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.NotifyStatus)
                    .HasColumnName("notify_status")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('PENDING')");

                entity.Property(e => e.NotifyTimeBefore).HasColumnName("notify_time_before");

                entity.Property(e => e.RecurrenceId).HasColumnName("recurrence_id");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_events_category");

                entity.HasOne(d => d.Recurrence)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.RecurrenceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_events_recurrence");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_events_users");
            });

            modelBuilder.Entity<Recurrence>(entity =>
            {
                entity.ToTable("recurrence");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndAfter).HasColumnName("end_after");

                entity.Property(e => e.RecurrenceInterval)
                    .HasColumnName("recurrence_interval")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RecurrencePattern)
                    .IsRequired()
                    .HasColumnName("recurrence_pattern")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__users__AB6E6164269B9034")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__users__F3DBC572D5FA31D8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
