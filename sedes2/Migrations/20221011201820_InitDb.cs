using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sedes2.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sedes");

            migrationBuilder.CreateTable(
                name: "Building",
                schema: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtRef = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "Sedes",
                        principalTable: "Building",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                schema: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "Sedes",
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "Sedes",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Sedes",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Seat_SeatId",
                        column: x => x.SeatId,
                        principalSchema: "Sedes",
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Building_Name",
                schema: "Sedes",
                table: "Building",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BuildingId",
                schema: "Sedes",
                table: "Reservation",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PersonId",
                schema: "Sedes",
                table: "Reservation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SeatId",
                schema: "Sedes",
                table: "Reservation",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BuildingId",
                schema: "Sedes",
                table: "Room",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Name",
                schema: "Sedes",
                table: "Room",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_Name",
                schema: "Sedes",
                table: "Seat",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_RoomId",
                schema: "Sedes",
                table: "Seat",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "Sedes");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Sedes");

            migrationBuilder.DropTable(
                name: "Seat",
                schema: "Sedes");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "Sedes");

            migrationBuilder.DropTable(
                name: "Building",
                schema: "Sedes");
        }
    }
}
