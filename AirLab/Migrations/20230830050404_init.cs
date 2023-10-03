using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirLab.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurpleAirSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastSeen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Altitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurpleAirSensors", x => x.Id);
                    table.UniqueConstraint("AK_PurpleAirSensors_SensorId", x => x.SensorId);
                });

            migrationBuilder.CreateTable(
                name: "PurpleAirData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: true),
                    Pressure = table.Column<double>(type: "float", nullable: true),
                    Pm_1_0 = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5 = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_alt = table.Column<double>(type: "float", nullable: true),
                    Pm_10_0 = table.Column<double>(type: "float", nullable: true),
                    Um_count_0_3 = table.Column<double>(type: "float", nullable: true),
                    Um_count_0_5 = table.Column<double>(type: "float", nullable: true),
                    Um_count_1_0 = table.Column<double>(type: "float", nullable: true),
                    Pm_1_0_cf_1 = table.Column<double>(type: "float", nullable: true),
                    Pm_1_0_atm = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_atm = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_cf_1 = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_10minute = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_30minute = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_60minute = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_6hour = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_24hour = table.Column<double>(type: "float", nullable: true),
                    Pm_2_5_1week = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurpleAirData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurpleAirData_PurpleAirSensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "PurpleAirSensors",
                        principalColumn: "SensorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurpleAirData_SensorId",
                table: "PurpleAirData",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurpleAirSensors_SensorId",
                table: "PurpleAirSensors",
                column: "SensorId",
                unique: true);

            migrationBuilder.InsertData(
                table: "PurpleAirSensors",
                columns: new[] { "SensorId", "Name", "LastSeen", "Latitude", "Longitude", "Altitude" },
                values: new object[] { 129953 , "ENVICARE-18" , DateTime.Now , 37.978294d , 23.672758d , 65 }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurpleAirData");

            migrationBuilder.DropTable(
                name: "PurpleAirSensors");
        }
    }
}
