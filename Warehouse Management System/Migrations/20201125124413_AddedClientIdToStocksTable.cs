using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse_Management_System.Migrations
{
    public partial class AddedClientIdToStocksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Clients_ClientId",
                table: "Stocks");

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "Stocks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Clients_ClientId",
                table: "Stocks",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Clients_ClientId",
                table: "Stocks");

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "Stocks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Clients_ClientId",
                table: "Stocks",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
