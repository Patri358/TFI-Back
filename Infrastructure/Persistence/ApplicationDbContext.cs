using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext 
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //    : base(options)
        //{
        //}

        //public DbSet<User> User { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
public List<User> Users
{
    get;
} = [
        new User { 
            Id = 1,
            Name = "Patricio",
            Dni = "416546",
            Email = "jfdslk@fewf",
            Hash = "fhfkwef",
            Telephone = "fwejkf",
            State = "fnjofjkw",
            BirthDate = new DateOnly(1995, 5, 12)
        },
        new User { 
            Id = 2,
            Name = "María",
            Dni = "789123",
            Email = "maria@example.com",
            Hash = "abc123xyz",
            Telephone = "3415551234",
            State = "Activo",
            BirthDate = new DateOnly(1998, 8, 22)
        },
        new User { 
            Id = 3,
            Name = "Carlos",
            Dni = "456789",
            Email = "carlos@example.com",
            Hash = "hashsecure789",
            Telephone = "3415555678",
            State = "Activo",
            BirthDate = new DateOnly(1990, 11, 3)
        }
    ];
    }
}
