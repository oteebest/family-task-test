using Core.Abstractions;
using Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class FamilyTaskContext : DbContext
    {

        public FamilyTaskContext(DbContextOptions<FamilyTaskContext> options):base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>(entity => {
                entity.HasKey(k => k.Id);
                entity.ToTable("Member");
                
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasOne(u => u.Member)
                      .WithMany(u => u.Tasks)
                      .HasForeignKey(u => u.AssignedMemberId);

                entity.Property(u => u.AssignedMemberId).IsRequired(false);

            });

            
        }
    }
}