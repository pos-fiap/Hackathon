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
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DefaultAvailability> DefaultAvailabilities { get; set; }
        public DbSet<SpecificAvailability> SpecificAvailabilities { get; set; }


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
                new Role { Id = 1, Description = "Doctor", CreateDate = DateTime.Now, AlterDate = DateTime.Now },
                new Role { Id = 2, Description = "Patient", CreateDate = DateTime.Now, AlterDate = DateTime.Now }
            );

            modelBuilder.Entity<RoleAccess>().HasData(
                new RoleAccess { Id = 1, RoleId = 1, Route = "Auth/RefreshToken" },
                new RoleAccess { Id = 2, RoleId = 1, Route = "Role" },
                new RoleAccess { Id = 3, RoleId = 1, Route = "User" },
                new RoleAccess { Id = 4, RoleId = 1, Route = "UserRole" },
                new RoleAccess { Id = 5, RoleId = 2, Route = "Auth/RefreshToken" },
                new RoleAccess { Id = 6, RoleId = 2, Route = "Patient" }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Doctor X", CPF = "12345678", Status = Status.Active },
                new Person { Id = 2, Name = "Patient Y", CPF = "134567890", Status = Status.Active }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "ricardomacieldasilva@hotmail.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("1"), PersonId = 1 },
                new User { Id = 2, Email = "patienty@hotmail.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("1"), PersonId = 2 }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, RoleId = 1, UserId = 1 },
                new UserRole { Id = 2, RoleId = 2, UserId = 2 }
                );

            modelBuilder.Entity<Doctor>().HasData(
                               new Doctor { Id = 1, PersonId = 1, CRM = "123456", Specialty = "Clinico Geral" }
                               );

            modelBuilder.Entity<Patient>().HasData(
                               new Patient { Id = 1, PersonId = 2, HealthInsuranceNumber = "12313231231" }
                               );

            modelBuilder.Entity<DefaultAvailability>().HasData(new DefaultAvailability
            {
                Id = 1,
                DoctorId = 1,
                StartMonday = new TimeSpan(8, 0, 0),
                EndMonday = new TimeSpan(18, 0, 0),
                LunchStartMonday = new TimeSpan(12, 0, 0),
                LunchEndMonday = new TimeSpan(13, 0, 0),

                StartTuesday = new TimeSpan(8, 0, 0),
                EndTuesday = new TimeSpan(18, 0, 0),
                LunchStartTuesday = new TimeSpan(12, 0, 0),
                LunchEndTuesday = new TimeSpan(13, 0, 0),

                StartWednesday = new TimeSpan(8, 0, 0),
                EndWednesday = new TimeSpan(18, 0, 0),
                LunchStartWednesday = new TimeSpan(12, 0, 0),
                LunchEndWednesday = new TimeSpan(13, 0, 0),

                StartThursday = new TimeSpan(8, 0, 0),
                EndThursday = new TimeSpan(18, 0, 0),
                LunchStartThursday = new TimeSpan(12, 0, 0),
                LunchEndThursday = new TimeSpan(13, 0, 0),

                StartFriday = new TimeSpan(8, 0, 0),
                EndFriday = new TimeSpan(18, 0, 0),
                LunchStartFriday = new TimeSpan(12, 0, 0),
                LunchEndFriday = new TimeSpan(13, 0, 0)
            });
        }

    }

}
