﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OrceiPdf.Web.Migrations
{
    public partial class Orcamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orcamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orcamentos");
        }
    }
}
