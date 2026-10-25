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
<<<<<<< Updated upstream
public List<User> Users
{
    get;
} = [
        new User { 
=======

        // usuarios
        public List<User> Users
        {
            get;
        } = [
                new User {
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
        ];

        // mascotas
        public List<Pet> Pets
        {
            get;
        } = [
        new Pet {
            Id = 1,
            ClientId = 1,
            Name = "Perro",
            Race = "Doberman",
            Gender = true,
            Species = "Perro",
            BirthDate = new DateOnly(2026, 11, 11)
        },
        new Pet {
            Id = 2,
            ClientId = 2,
            Name = "Gato",
            Race = "Gato",
            Gender = false,
            Species = "Gato",
            BirthDate = new DateOnly(2026, 11, 11)
        },
        new Pet {
            Id = 3,
            ClientId = 3,
            Name = "Caballo",
            Race = "Caballo",
            Gender = false,
            Species = "Caballo",
            BirthDate = new DateOnly(2026, 11, 11)
        }
>>>>>>> Stashed changes
    ];

        public List<Order> Orders
        {
            get;
        } = [
            new Order{
                Id = 1,
                ClientId = 1,
                OrderDate = DateTime.Now,
                DeliveryDate = null,
                PreparationDate = null,
                PaymentMethod = 
                State
                Total
            }
            ];

    }
}
