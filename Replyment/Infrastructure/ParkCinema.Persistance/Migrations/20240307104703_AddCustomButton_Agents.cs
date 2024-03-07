using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Replyment.Persistance.Migrations
{
    public partial class AddCustomButton_Agents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domain_AspNetUsers_AppUserId",
                table: "Domain");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_AspNetUsers_AppUserId",
                table: "Subscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Domain",
                table: "Domain");

            migrationBuilder.DropIndex(
                name: "IX_Domain_AppUserId",
                table: "Domain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomizeButtons",
                table: "CustomizeButtons");

            migrationBuilder.RenameTable(
                name: "Subscription",
                newName: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "Domain",
                newName: "Domains");

            migrationBuilder.RenameTable(
                name: "CustomizeButtons",
                newName: "WidgetAllStyles");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_AppUserId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_AppUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "WidgetAllStyleId",
                table: "Domains",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domains",
                table: "Domains",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WidgetAllStyles",
                table: "WidgetAllStyles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomButtons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWhatsapp = table.Column<bool>(type: "bit", nullable: false),
                    WidgetAllStyleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModiffiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomButtons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomButtons_WidgetAllStyles_WidgetAllStyleId",
                        column: x => x.WidgetAllStyleId,
                        principalTable: "WidgetAllStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Posistion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOrLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomButtonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModiffiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_CustomButtons_CustomButtonId",
                        column: x => x.CustomButtonId,
                        principalTable: "CustomButtons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domains_AppUserId",
                table: "Domains",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_WidgetAllStyleId",
                table: "Domains",
                column: "WidgetAllStyleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CustomButtonId",
                table: "Agents",
                column: "CustomButtonId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomButtons_WidgetAllStyleId",
                table: "CustomButtons",
                column: "WidgetAllStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_AspNetUsers_AppUserId",
                table: "Domains",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_WidgetAllStyles_WidgetAllStyleId",
                table: "Domains",
                column: "WidgetAllStyleId",
                principalTable: "WidgetAllStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_AppUserId",
                table: "Subscriptions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domains_AspNetUsers_AppUserId",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Domains_WidgetAllStyles_WidgetAllStyleId",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_AppUserId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "CustomButtons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WidgetAllStyles",
                table: "WidgetAllStyles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Domains",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_AppUserId",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_WidgetAllStyleId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "WidgetAllStyleId",
                table: "Domains");

            migrationBuilder.RenameTable(
                name: "WidgetAllStyles",
                newName: "CustomizeButtons");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "Subscription");

            migrationBuilder.RenameTable(
                name: "Domains",
                newName: "Domain");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_AppUserId",
                table: "Subscription",
                newName: "IX_Subscription_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomizeButtons",
                table: "CustomizeButtons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domain",
                table: "Domain",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Domain_AppUserId",
                table: "Domain",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Domain_AspNetUsers_AppUserId",
                table: "Domain",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_AspNetUsers_AppUserId",
                table: "Subscription",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
