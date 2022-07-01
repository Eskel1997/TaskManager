using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Entities.Concrete;

namespace TASKMANAGER.DB.DAL
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options): base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserTeam> TeamUsers { get; set; }
        public DbSet<UserPermissions> UserPermissions {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<UserTeam>().WithOne(c => c.AddedBy).HasForeignKey(c => c.AddedById);
            modelBuilder.Entity<User>().HasMany<UserTeam>().WithOne(c => c.User).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<User>().HasMany<Task>().WithOne(c => c.CreatedBy).HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<User>().HasMany<Task>().WithOne(c => c.Owner).HasForeignKey(c => c.OwnerId);
        }
    }
}
