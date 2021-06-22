using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrceiPdf.Web.Migrations
{
    public partial class Client_Orcamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Orcamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_ClienteId",
                table: "Orcamentos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Clientes_ClienteId",
                table: "Orcamentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Clientes_ClienteId",
                table: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_ClienteId",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Orcamentos");
        }
    }
}
