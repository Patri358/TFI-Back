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
            Rol = Role.Admin,
            Name = "Patricio",
            Dni = "416546",
            Email = "jfdslk@fewf",
            PasswordHash = "fhfkwef",
            Telephone = "fwejkf",
            State = "fnjofjkw",
            BirthDate = new DateOnly(1995, 5, 12)
        },
        new User { 
            Id = 2,
            Rol = Role.Veterinario,
            Name = "María",
            Dni = "789123",
            Email = "maria@example.com",
            PasswordHash = "abc123xyz",
            Telephone = "3415551234",
            State = "Activo",
            BirthDate = new DateOnly(1998, 8, 22)
        },
        new User { 
            Id = 3,
            Rol = Role.Cliente,
            Name = "Carlos",
            Dni = "456789",
            Email = "carlos@example.com",
            PasswordHash = "hashsecure789",
            Telephone = "3415555678",
            State = "Activo",
            BirthDate = new DateOnly(1990, 11, 3)
        }
    ];
    }
}
