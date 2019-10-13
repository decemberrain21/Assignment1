using System;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;
namespace Assignment
{
    public class AssignmentDBContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AssignmentDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = Guid.NewGuid(),
                    Name = "Peter Even",
                    Email = "peter@gmail.com",
                    Gender = 'M',
                    RegisteredDate = new DateTime(2019, 03, 02),
                    SelectedEvents = "Day 1,Day 3",
                    AdditionalRequest = "To Provide Rooms"
                },
                new Users
                {
                    Id = Guid.NewGuid(),
                    Name = "Felix Jones",
                    Email = "felix@gmail.com",
                    Gender = 'M',
                    RegisteredDate = new DateTime(2019, 03, 08),
                    SelectedEvents = "Day 1",
                    AdditionalRequest = "To Provide Seats"
                },
                new Users
                {
                    Id = Guid.NewGuid(),
                    Name = "Camila Cheng",
                    Email = "camela@gmail.com",
                    Gender = 'F',
                    RegisteredDate = new DateTime(2019, 03, 12),
                    SelectedEvents = "Day 3",
                    AdditionalRequest = "To Provide Food"
                }
            );
        }
    }
    
}
