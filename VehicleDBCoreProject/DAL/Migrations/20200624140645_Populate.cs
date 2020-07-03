using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Populate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleMakers",
                columns: new[] { "VehicleMakeId", "Abrv", "Name" },
                values: new object[,]
                {
                    { 1, "BMW", "Bmw" },
                    { 2, "JAG", "Jaguar" },
                    { 3, "FRD", "Ford" },
                    { 4, "NIS", "Nissan" },
                    { 5, "VW", "VolksWagen" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "VehicleModelId", "Abrv", "MakerVehicleMakeId", "Name", "VehicleMakeId" },
                values: new object[,]
                {
                    { 13, "MST", null, "Mustang", 3 },
                    { 12, "FTP", null, "F-Type Coupe", 2 },
                    { 11, "FRN", null, "Frontier", 4 },
                    { 10, "IPC", null, "I-Pace", 2 },
                    { 9, "350", null, "350Z", 4 },
                    { 8, "GLI", null, "Jetta GLI", 5 },
                    { 5, "GTR", null, "GT-R", 4 },
                    { 6, "FCS", null, "Focus", 3 },
                    { 14, "ART", null, "Arteon", 5 },
                    { 4, "XE", null, "XE", 2 },
                    { 3, "F15", null, "F-150", 3 },
                    { 2, "340", null, "340 Gran Turismo", 1 },
                    { 1, "TO2", null, "Touareg2", 5 },
                    { 7, "550", null, "M550", 1 },
                    { 15, "228", null, "228 Gran Coupe", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 15);
        }
    }
}
