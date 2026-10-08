using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistences
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       /* public List<User> Users
        {
            get;
        } = [
                new User{ 
                    Id = 1,
                    Name = "Patricio",
                    Dni = "416546",
                    Email = "jfdslk@fewf",
                    Hash= "fhfkwef",
                    Telefone = "fwejkf",
                    State = "fnjofjkw",
                    BirthDate = DateTime.Now
                }
            ];
    */
    }
}
