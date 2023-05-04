using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2._0.Migrations
{
    public partial class changeseed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Fname", "Lname", "Pnr", "UserName" },
                values: new object[,]
                {
                    { 1, "James", "Hetfield", "199010109285", "James1" },
                    { 2, "Tony", "Stark", "198011259287", "Ironman" },
                    { 3, "Keanu", "Reeves", "197002169283", "Neo" }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 1, "Car" });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Color", "Make", "Model", "NrOfWheels", "ParkingLot", "RegNr", "TimeOfArrival", "UserId", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, "Silver", "Volvo", "V70", 0, 1, "ABC123", new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6494), 1, 1 },
                    { 2, "Red", "Saab", "95", 0, 2, "DEF456", new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6539), 1, 1 },
                    { 3, "Green", "Ford", "Mustang", 0, 3, "GHI789", new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6542), 2, 1 },
                    { 4, "Black", "Harley-Davidson", "Pan America", 0, 4, "JKL891", new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6545), 2, 1 },
                    { 5, "Orange", "Scania", "XT", 0, 5, "MNO345", new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6548), 3, 1 },
                    { 6, "Yellow", "Scania", "zzz", 0, 6, "PQR912", new DateTime(2022, 8, 15, 11, 9, 13, 658, DateTimeKind.Local).AddTicks(6551), 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
