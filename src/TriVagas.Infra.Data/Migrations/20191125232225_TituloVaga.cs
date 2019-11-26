using Microsoft.EntityFrameworkCore.Migrations;

namespace TriVagas.Infra.Data.Migrations
{
    public partial class TituloVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Opportunities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Opportunities");
        }
    }
}
