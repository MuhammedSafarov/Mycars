using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mycars.Migrations
{
    public partial class newMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeaturesId",
                table: "Brands",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Region = table.Column<string>(nullable: true),
                    AZN = table.Column<int>(nullable: false),
                    Colour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_FeaturesId",
                table: "Brands",
                column: "FeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Features_FeaturesId",
                table: "Brands",
                column: "FeaturesId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Features_FeaturesId",
                table: "Brands");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Brands_FeaturesId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "FeaturesId",
                table: "Brands");
        }
    }
}
