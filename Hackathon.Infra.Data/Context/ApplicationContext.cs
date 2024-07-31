using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hackathon.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<RoleAccess> RoleAccess { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapEntity(modelBuilder);
            DisableDeleteCascade(modelBuilder);

            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);
        }

        private void MapEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void DisableDeleteCascade(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Description = "Admin", CreateDate = DateTime.Now, AlterDate = DateTime.Now },
                new Role { Id = 2, Description = "Employee", CreateDate = DateTime.Now, AlterDate = DateTime.Now }
            );

            modelBuilder.Entity<RoleAccess>().HasData(
                new RoleAccess { Id = 1, RoleId = 1, Route = "Auth/RefreshToken" },
                new RoleAccess { Id = 2, RoleId = 1, Route = "Customer" },
                new RoleAccess { Id = 3, RoleId = 1, Route = "CustomerVehicle" },
                new RoleAccess { Id = 4, RoleId = 1, Route = "ParkingSpot" },
                new RoleAccess { Id = 5, RoleId = 1, Route = "Reservation" },
                new RoleAccess { Id = 6, RoleId = 1, Route = "Role" },
                new RoleAccess { Id = 7, RoleId = 1, Route = "User" },
                new RoleAccess { Id = 8, RoleId = 1, Route = "UserRole" },
                new RoleAccess { Id = 9, RoleId = 1, Route = "Valet" },
                new RoleAccess { Id = 10, RoleId = 1, Route = "Vehicle" },
                new RoleAccess { Id = 11, RoleId = 2, Route = "Customer" },
                new RoleAccess { Id = 12, RoleId = 2, Route = "Reservation" },
                new RoleAccess { Id = 13, RoleId = 2, Route = "Vehicle" },
                new RoleAccess { Id = 14, RoleId = 2, Route = "Auth/RefreshToken" }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "admin", Document = "12345678", Status = Status.Active },
                new Person { Id = 2, Name = "cliente", Document = "134567890", Status = Status.Active },
                new Person { Id = 3, Name = "valet", Document = "199999990", Status = Status.Active }
                );

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"), PersonId = 1 });

            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, RoleId = 1, UserId = 1 });



        }

    }

}
