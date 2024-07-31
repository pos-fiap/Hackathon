﻿// <auto-generated />
using System;
using Hackathon.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackathon.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240731011725_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hackathon.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Customer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PersonId = 2
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.CustomerVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CustomerVehicle", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            PersonId = 2,
                            VehicleId = 1
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.ParkingSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ParkingSpot", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A1",
                            Status = true
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Document");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Document = "12345678",
                            Name = "admin",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Document = "134567890",
                            Name = "cliente",
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            Document = "199999990",
                            Name = "valet",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerVehicleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Entrance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Exit")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<int>("ParkingSpotId")
                        .HasColumnType("int");

                    b.Property<int>("TimeParked")
                        .HasColumnType("int");

                    b.Property<int>("ValetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerVehicleId");

                    b.HasIndex("ParkingSpotId");

                    b.HasIndex("ValetId");

                    b.ToTable("Reservation", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerVehicleId = 1,
                            Entrance = new DateTime(2024, 7, 30, 22, 17, 25, 121, DateTimeKind.Local).AddTicks(4138),
                            Finished = false,
                            Paid = false,
                            ParkingSpotId = 1,
                            TimeParked = 0,
                            ValetId = 1
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AlterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlterDate = new DateTime(2024, 7, 30, 22, 17, 25, 7, DateTimeKind.Local).AddTicks(6968),
                            CreateDate = new DateTime(2024, 7, 30, 22, 17, 25, 7, DateTimeKind.Local).AddTicks(6958),
                            Description = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            AlterDate = new DateTime(2024, 7, 30, 22, 17, 25, 7, DateTimeKind.Local).AddTicks(6970),
                            CreateDate = new DateTime(2024, 7, 30, 22, 17, 25, 7, DateTimeKind.Local).AddTicks(6970),
                            Description = "Employee"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.RoleAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Route");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleAccess", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            Route = "Auth/RefreshToken"
                        },
                        new
                        {
                            Id = 2,
                            RoleId = 1,
                            Route = "Customer"
                        },
                        new
                        {
                            Id = 3,
                            RoleId = 1,
                            Route = "CustomerVehicle"
                        },
                        new
                        {
                            Id = 4,
                            RoleId = 1,
                            Route = "ParkingSpot"
                        },
                        new
                        {
                            Id = 5,
                            RoleId = 1,
                            Route = "Reservation"
                        },
                        new
                        {
                            Id = 6,
                            RoleId = 1,
                            Route = "Role"
                        },
                        new
                        {
                            Id = 7,
                            RoleId = 1,
                            Route = "User"
                        },
                        new
                        {
                            Id = 8,
                            RoleId = 1,
                            Route = "UserRole"
                        },
                        new
                        {
                            Id = 9,
                            RoleId = 1,
                            Route = "Valet"
                        },
                        new
                        {
                            Id = 10,
                            RoleId = 1,
                            Route = "Vehicle"
                        },
                        new
                        {
                            Id = 11,
                            RoleId = 2,
                            Route = "Customer"
                        },
                        new
                        {
                            Id = 12,
                            RoleId = 2,
                            Route = "Reservation"
                        },
                        new
                        {
                            Id = 13,
                            RoleId = 2,
                            Route = "Vehicle"
                        },
                        new
                        {
                            Id = 14,
                            RoleId = 2,
                            Route = "Auth/RefreshToken"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("PasswordHash");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "$2a$11$Rj/gzvbsy3VcoSiU.mPNd.h2MAtu/xNPuPiXB0Ow9UhTssQKtVWTO",
                            PersonId = 1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Valet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("UserId");

                    b.Property<DateTime?>("CNHExpiration")
                        .IsRequired()
                        .HasColumnType("datetime")
                        .HasColumnName("RoleId");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Valet", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CNH = "98765432",
                            CNHExpiration = new DateTime(2027, 7, 30, 22, 17, 25, 121, DateTimeKind.Local).AddTicks(4069),
                            PersonId = 3
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicle", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Toyota",
                            LicensePlate = "ABC123",
                            Model = "Corola",
                            VehicleType = 1
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Customer", b =>
                {
                    b.HasOne("Hackathon.Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Hackathon.Domain.Entities.CustomerVehicle", "CustomerVehicle")
                        .WithMany()
                        .HasForeignKey("CustomerVehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Entities.ParkingSpot", null)
                        .WithMany("Reservations")
                        .HasForeignKey("ParkingSpotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Entities.Valet", "Valet")
                        .WithMany()
                        .HasForeignKey("ValetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerVehicle");

                    b.Navigation("Valet");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.RoleAccess", b =>
                {
                    b.HasOne("Hackathon.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.User", b =>
                {
                    b.HasOne("Hackathon.Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Hackathon.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Valet", b =>
                {
                    b.HasOne("Hackathon.Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.ParkingSpot", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
