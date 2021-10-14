using ITSmartFinanceTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinanceTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskOnUser> TasksOnUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("PK_User");
                entity.Property(e => e.Name)
                .HasColumnName("Us_Name");
            });
            modelBuilder.Entity<Board>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("PK_Board");
                entity.Property(e => e.Description)
                .HasColumnName("Br_Description");
            });
            modelBuilder.Entity<Task>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("PK_Task");
                entity.Property(e => e.Description)
                .HasColumnName("Tk_Description");
                entity.HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .HasConstraintName("FK_Task_Board");
            });
            modelBuilder.Entity<TaskOnUser>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("PK_Id");
                entity.HasOne(tou => tou.Task)
                .WithMany(t => t.Users)
                .HasForeignKey(tou => tou.TaskId)
                .HasConstraintName("FK_TOU_Task");
                entity.HasOne(tou => tou.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(tou => tou.UserId)
                .HasConstraintName("FK_TOU_User");
            });
        }
    }
   
}
