using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace eTickets.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTORS",
                columns: table => new
                {
                    Id = table.Column<Int32>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<String>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_ACTORS", x => x.Id));

            migrationBuilder.CreateTable(
                name: "CINEMAS",
                columns: table => new
                {
                    Id = table.Column<Int32>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<String>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_CINEMAS", x => x.Id));

            migrationBuilder.CreateTable(
                name: "PRODUCERS",
                columns: table => new
                {
                    Id = table.Column<Int32>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<String>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_PRODUCERS", x => x.Id));

            migrationBuilder.CreateTable(
                name: "MOVIES",
                columns: table => new
                {
                    Id = table.Column<Int32>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<Double>(type: "float", nullable: false),
                    ImageURL = table.Column<String>(type: "nvarchar(max)", nullable: true),
                    SatrtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieCategory = table.Column<Int32>(type: "int", nullable: false),
                    CinemaId = table.Column<Int32>(type: "int", nullable: false),
                    ProducerId = table.Column<Int32>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MOVIES_CINEMAS_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "CINEMAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MOVIES_PRODUCERS_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "PRODUCERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACTORS_MOVIES",
                columns: table => new
                {
                    MovieId = table.Column<Int32>(type: "int", nullable: false),
                    ActorId = table.Column<Int32>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTORS_MOVIES", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ACTORS_MOVIES_ACTORS_ActorId",
                        column: x => x.ActorId,
                        principalTable: "ACTORS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACTORS_MOVIES_MOVIES_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MOVIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTORS_MOVIES_MovieId",
                table: "ACTORS_MOVIES",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIES_CinemaId",
                table: "MOVIES",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIES_ProducerId",
                table: "MOVIES",
                column: "ProducerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTORS_MOVIES");

            migrationBuilder.DropTable(
                name: "ACTORS");

            migrationBuilder.DropTable(
                name: "MOVIES");

            migrationBuilder.DropTable(
                name: "CINEMAS");

            migrationBuilder.DropTable(
                name: "PRODUCERS");
        }
    }
}
