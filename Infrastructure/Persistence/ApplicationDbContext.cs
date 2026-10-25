using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext
    {
        public List<User> Users { get; } = [
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

        public List<Pet> Pets { get; } = [
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
        ];

        public List<Order> Orders { get; } = [
            new Order {
                Id = 1,
                CustomerId = 1,
                OrderDate = DateTime.Now,
                PaymentMethod = "Efectivo",
                Status = OrderStatus.Pendiente,
                TotalAmount = 1500.0m
            }
        ];
    }
}

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //    : base(options)
        //{
        //}

        //public DbSet<User> User { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}