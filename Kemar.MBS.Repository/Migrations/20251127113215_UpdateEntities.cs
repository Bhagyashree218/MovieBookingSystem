using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemar.MBS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BookingSeats");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BookingSeats");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BookingSeats");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "BookingSeats");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BookingSeats");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Theatres",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Theatres",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Shows",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Shows",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Screens",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Screens",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Movies",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Movies",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Cities",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Cities",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Bookings",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Bookings",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Admins",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Admins",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<string>(
                name: "SeatType",
                table: "Seats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatType",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Theatres",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Theatres",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Shows",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Shows",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Screens",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Screens",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Movies",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Movies",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Cities",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Cities",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Bookings",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Bookings",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Admins",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Admins",
                newName: "ModifiedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Seats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Seats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BookingSeats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "BookingSeats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BookingSeats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "BookingSeats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "BookingSeats",
                type: "int",
                nullable: true);
        }
    }
}
