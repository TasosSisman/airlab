using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirLab.Migrations
{
    /// <inheritdoc />
    public partial class AddedApplicationSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationSettings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, "PurpleAirApiKey", "C35AD90F-F7E3-11ED-BD21-42010A800008" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationSettings");

            migrationBuilder.DeleteData(
                table: "PurpleAirSensors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
