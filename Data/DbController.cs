using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApiQuizApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetApiQuizApp.Data
{
    public class DbController : DbContext
    {
        public DbController(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quiz> Quizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Results)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
           
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}