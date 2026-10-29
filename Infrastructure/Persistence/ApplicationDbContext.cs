using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<ClinicalRecord> ClinicalRecords { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ReasonCancellation> ReasonCancellations { get; set; }
        public DbSet<ReasonConsultation>  ReasonConsultations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceVeterinary> ServiceVeterinaries { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftEvent> ShiftEvents { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}