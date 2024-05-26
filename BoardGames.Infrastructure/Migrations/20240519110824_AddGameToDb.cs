using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoardGames.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGameToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categorys",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerNumber = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Additional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Additional", "CategoryId", "Description", "ImageUrl", "Name", "PlayerNumber" },
                values: new object[,]
                {
                    { 1, "Variações de tabuleiro, cartas de desenvolvimento, recursos (madeira, trigo, lã, etc.)", 1, "Catan é um jogo de estratégia no qual os jogadores competem para construir colônias e expandir seu território em uma ilha fictícia.", "https://example.com/catan-image", "Catan", 3 },
                    { 2, "Varios modos, diferentes edições temáticas, cartas de sorte/azar.", 3, "Monopólio é um jogo clássico de negociação imobiliária no qual os jogadores compram, vendem e trocam propriedades para acumular riqueza e falir os seus adversários.", "https://example.com/monopoly-image", "Monopólio", 2 },
                    { 3, "Tabuleiros assimétricos, cartas de objetivos, miniaturas de unidades.", 1, "Scythe é um jogo de estratégia ambientado em uma realidade alternativa dos anos 1920, onde os jogadores controlam facções e competem pela supremacia em uma terra devastada pela guerra.", "https://example.com/scythe-image", "Scythe", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_CategoryId",
                table: "Games",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
