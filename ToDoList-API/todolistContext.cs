using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToDoList_DAL;

namespace ToDoList_API
{
    public partial class todolistContext : DbContext
    {
        public todolistContext()
        {
        }

        public todolistContext(DbContextOptions<todolistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Task_> Tasks { get; set; } = null!;
        public virtual DbSet<Urgency> Urgencies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-77MT8LVK; Database=todolist; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(70);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusName).HasMaxLength(70);
            });

            modelBuilder.Entity<Task_>(entity =>
            {
                entity.Property(e => e.TaskDescription).HasMaxLength(300);

                entity.Property(e => e.TaskName).HasMaxLength(70);

                entity.HasOne(d => d.TaskCategoryNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskCategory)
                    .HasConstraintName("FK__Tasks__TaskCateg__3B75D760");

                entity.HasOne(d => d.TaskStatusNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskStatus)
                    .HasConstraintName("FK__Tasks__TaskStatu__3C69FB99");

                entity.HasOne(d => d.TaskUrgencyNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskUrgency)
                    .HasConstraintName("FK__Tasks__TaskUrgen__3D5E1FD2");
            });

            modelBuilder.Entity<Urgency>(entity =>
            {
                entity.ToTable("Urgency");

                entity.Property(e => e.UrgencyName).HasMaxLength(75);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
