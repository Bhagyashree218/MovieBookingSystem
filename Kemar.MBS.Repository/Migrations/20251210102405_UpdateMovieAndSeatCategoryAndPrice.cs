using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemar.MBS.Repository.Migrations
{
    public partial class UpdateMovieAndSeatCategoryAndPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatType",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Movies",
                newName: "Category");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Seats",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SeatCategory",
                table: "Seats",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "Movies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "BannerUrl",
                table: "Movies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Movies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CastImages",
                table: "Movies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CensorRating",
                table: "Movies",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalleryImages",
                table: "Movies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ImdbRating",
                table: "Movies",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikesPercentage",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Movies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "Movies",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "SeatCategory",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BannerUrl",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CastImages",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CensorRating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GalleryImages",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImdbRating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "LikesPercentage",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Movies",
                newName: "Genre");

            migrationBuilder.AddColumn<string>(
                name: "SeatType",
                table: "Seats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
