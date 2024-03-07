using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Replyment.Persistance.Migrations
{
    public partial class UpdateChangeTableColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domains_WidgetAllStyles_WidgetAllStyleId",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_WidgetAllStyleId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "WidgetAllStyleId",
                table: "Domains");

            migrationBuilder.AddColumn<Guid>(
                name: "DomainId",
                table: "WidgetAllStyles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WidgetAllStyles_DomainId",
                table: "WidgetAllStyles",
                column: "DomainId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetAllStyles_Domains_DomainId",
                table: "WidgetAllStyles",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetAllStyles_Domains_DomainId",
                table: "WidgetAllStyles");

            migrationBuilder.DropIndex(
                name: "IX_WidgetAllStyles_DomainId",
                table: "WidgetAllStyles");

            migrationBuilder.DropColumn(
                name: "DomainId",
                table: "WidgetAllStyles");

            migrationBuilder.AddColumn<Guid>(
                name: "WidgetAllStyleId",
                table: "Domains",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Domains_WidgetAllStyleId",
                table: "Domains",
                column: "WidgetAllStyleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_WidgetAllStyles_WidgetAllStyleId",
                table: "Domains",
                column: "WidgetAllStyleId",
                principalTable: "WidgetAllStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
