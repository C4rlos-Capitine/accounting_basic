using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acounting_basic.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClassesContas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tipo_contaId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    num_ordem = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_tipo_contaId",
                table: "Contas",
                column: "tipo_contaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_tipoContas_tipo_contaId",
                table: "Contas",
                column: "tipo_contaId",
                principalTable: "tipoContas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_tipoContas_tipo_contaId",
                table: "Contas");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropIndex(
                name: "IX_Contas_tipo_contaId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "tipo_contaId",
                table: "Contas");
        }
    }
}
