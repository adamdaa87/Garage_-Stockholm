using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Models;
using Garage3._0.Core.Entities;

namespace Garage_2._0.Data
{
    public class Garage_2_0Context : DbContext
    {
        public Garage_2_0Context (DbContextOptions<Garage_2_0Context> options)
            : base(options)
        {
        }
        public DbSet<Vehicle> Vehicle {  get ; set; }
        public DbSet<User>? User { get; set; }
        public DbSet<VehicleType>? VehicleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, UserId = 1, VehicleTypeId = 1, ParkingLot = 1, RegNr = "ABC123", Make = "Volvo", Model = "V70", Color = "Silver", TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 2, UserId = 1, VehicleTypeId = 2, ParkingLot = 2, RegNr = "DEF456", Make = "Saab", Model = "95", Color = "Red", TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 3, UserId = 2, VehicleTypeId = 1, ParkingLot = 3, RegNr = "GHI789", Make = "Ford", Model = "Mustang", Color = "Green", TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 4, UserId = 2, VehicleTypeId = 3, ParkingLot = 4, RegNr = "JKL891", Make = "Harley-Davidson", Model = "Pan America", Color = "Black", TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 5, UserId = 3, VehicleTypeId = 2, ParkingLot = 5, RegNr = "MNO345", Make = "Scania", Model = "XT", Color = "Orange", TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 6, UserId = 4, VehicleTypeId = 1, ParkingLot = 5, RegNr = "MNO345", Make = "Scania", Model = "XT", Color = "Orange", TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 7, UserId = 3, VehicleTypeId = 1, ParkingLot = 6, RegNr = "PQR912", Make = "Scania", Model = "zzz", Color = "Yellow", TimeOfArrival = DateTime.Now }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Fname = "James", Lname = "Hetfield", Id = 1, Pnr = "199010109285", UserName = "James1" },
                new User { Fname = "Tony", Lname = "Stark", Id = 2, Pnr = "198011259287", UserName = "Ironman" },
                new User { Fname = "Keanu", Lname = "Reeves", Id = 3, Pnr = "197002169283", UserName = "Neo" },
                new User { Fname = "keanu", Lname = "Greeves", Id = 4, Pnr = "196402169281", UserName = "Neonboy" }
                );

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = 1, TypeName = "Car" },
                new VehicleType { Id = 2, TypeName = "Motorcycle" },
                new VehicleType { Id = 3, TypeName = "Bus" }
                );

        }

    }
}
