using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celo_user_api.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
         : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Title = "Mr",
                FirstName = "Gregorio",
                LastName = "Kiehn",
                Email = "Gregorio.Kiehn@royce.org",
                PhoneNumber = 123456

            }, new User
            {
                Id = 2,
                Title = "Mr",
                FirstName = "Norbert",
                LastName = "Bailey",
                Email = "tanfrog09@gmail.com",
                PhoneNumber = 654321
            }, new User
            {
                Id = 3,
                Title = "Mr",
                FirstName = "Harry",
                LastName = "Potter",
                Email = "hp@hogwarts.com",
                PhoneNumber = 654321
            });
        }

    }
}