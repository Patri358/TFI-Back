using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext
    {
        // usuarios
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
        ];

        // ordenes
        public List<Order> Orders
        {
            get;
        } = [
            new Order {
                Id = 1,
                ClientId = 1,
                OrderDate = DateTime.Now,
                DeliveryDate = null,
                PreparationDate = null,
                PaymentMethod = "Efectivo",
                Status = OrderStatus.PendientePago,
                Total = 0,
                Items = []
            },
            new Order{
                Id = 2,
                ClientId= 2,
                OrderDate= DateTime.Now,
                DeliveryDate= null,
                PreparationDate= null,
                PaymentMethod = "Crédito",
                Status = OrderStatus.Pagado,
                Total = 1000,
                Items = []
            }
        ];

        // items
        public List<Item> Items
        {
            get;
        } = [
            new Item{
                Id = 1,
                Name = "Comida para gatos",
                Price = 50,
                Stock = 0,
                Available = false,
                Description = "Comida para gatos" 
            },
            new Item{
                Id = 2,
                Name = "Comida para perros",
                Price = 100,
                Stock = 25,
                Available = true,
                Description = "Comida para perros"
            }
            ];

        // turnos
        public List<Shift> Shifts
        {
            get;
        } = [
            new Shift{
                Id = 1,
                PetId = 1,
                VeterinaryId = 1,
                ClientId = 1,
                ServiceId = 1,
                Status = ShiftStatus.Completado,
                ClientObs = "Sin observaciones",
                InitialDate = DateTime.Now,
                EndDate = DateTime.Now,
            },
            new Shift{
                Id = 2,
                PetId = 2,
                VeterinaryId = 2,
                ClientId = 2,
                ServiceId = 2,
                Status = ShiftStatus.Activo,
                ClientObs = "Sin observaciones",
                InitialDate = DateTime.Now,
                EndDate = DateTime.Now,
            }
            ];

        // sesiones
        public List<Sesion> Sessions
        {
            get;
        } = [
            new Sesion{
                 Id = 1,
                 UserId = 1,
                 Token = "token1",
                 EmissionDate = DateTime.Now,
                 RevocationDate = DateTime.Now,
                 ExpirationDate = DateTime.Now
            },
            new Sesion{
                 Id = 2,
                 UserId = 2,
                 Token = "token2",
                 EmissionDate = DateTime.Now,
                 RevocationDate = DateTime.Now,
                 ExpirationDate = DateTime.Now
            }
            ];
    }
}