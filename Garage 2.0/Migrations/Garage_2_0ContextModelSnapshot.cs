﻿// <auto-generated />
using System;
using Garage_2._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage_2._0.Migrations
{
    [DbContext(typeof(Garage_2_0Context))]
    partial class Garage_2_0ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Garage3._0.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pnr")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fname = "James",
                            Lname = "Hetfield",
                            Pnr = "199010109285",
                            UserName = "James1"
                        },
                        new
                        {
                            Id = 2,
                            Fname = "Tony",
                            Lname = "Stark",
                            Pnr = "198011259287",
                            UserName = "Ironman"
                        },
                        new
                        {
                            Id = 3,
                            Fname = "Keanu",
                            Lname = "Reeves",
                            Pnr = "197002169283",
                            UserName = "Neo"
                        });
                });

            modelBuilder.Entity("Garage3._0.Core.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("NrOfWheels")
                        .HasColumnType("int");

                    b.Property<int>("ParkingLot")
                        .HasColumnType("int");

                    b.Property<string>("RegNr")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("TimeOfArrival")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Silver",
                            Make = "Volvo",
                            Model = "V70",
                            NrOfWheels = 0,
                            ParkingLot = 1,
                            RegNr = "ABC123",
                            TimeOfArrival = new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6494),
                            UserId = 1,
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Color = "Red",
                            Make = "Saab",
                            Model = "95",
                            NrOfWheels = 0,
                            ParkingLot = 2,
                            RegNr = "DEF456",
                            TimeOfArrival = new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6539),
                            UserId = 1,
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Color = "Green",
                            Make = "Ford",
                            Model = "Mustang",
                            NrOfWheels = 0,
                            ParkingLot = 3,
                            RegNr = "GHI789",
                            TimeOfArrival = new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6542),
                            UserId = 2,
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Color = "Black",
                            Make = "Harley-Davidson",
                            Model = "Pan America",
                            NrOfWheels = 0,
                            ParkingLot = 4,
                            RegNr = "JKL891",
                            TimeOfArrival = new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6545),
                            UserId = 2,
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Color = "Orange",
                            Make = "Scania",
                            Model = "XT",
                            NrOfWheels = 0,
                            ParkingLot = 5,
                            RegNr = "MNO345",
                            TimeOfArrival = new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6548),
                            UserId = 3,
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Color = "Yellow",
                            Make = "Scania",
                            Model = "zzz",
                            NrOfWheels = 0,
                            ParkingLot = 6,
                            RegNr = "PQR912",
                            TimeOfArrival = new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6551),
                            UserId = 3,
                            VehicleTypeId = 1
                        });
                });

            modelBuilder.Entity("Garage3._0.Core.Entities.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Car"
                        });
                });

            modelBuilder.Entity("Garage3._0.Core.Entities.Vehicle", b =>
                {
                    b.HasOne("Garage3._0.Core.Entities.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage3._0.Core.Entities.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("Garage3._0.Core.Entities.User", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Garage3._0.Core.Entities.VehicleType", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
