using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Replyment.Persistance.Migrations
{
    public partial class AddDomain_WidgetAllStyle_Subscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "CustomizeButtons",
                newName: "Shadow");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "CustomizeButtons",
                newName: "Opacity");

            migrationBuilder.RenameColumn(
                name: "BackgroundColor",
                table: "CustomizeButtons",
                newName: "WidgetColor");

            migrationBuilder.AddColumn<string>(
                name: "AgentName",
                table: "CustomizeButtons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AgentPosition",
                table: "CustomizeButtons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarImage",
                table: "CustomizeButtons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackgroundStyle",
                table: "CustomizeButtons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ButtonSize",
                table: "CustomizeButtons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ButtonStyle",
                table: "CustomizeButtons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CallToAction",
                table: "CustomizeButtons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Display",
                table: "CustomizeButtons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "GoogleAnalytics",
                table: "CustomizeButtons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Greeting",
                table: "CustomizeButtons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GreetingMessage",
                table: "CustomizeButtons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Position",
                table: "CustomizeButtons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "WidgetButtonImage",
                table: "CustomizeButtons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DomainUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModiffiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domain_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionLevel = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModiffiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domain_AppUserId",
                table: "Domain",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_AppUserId",
                table: "Subscription",
                column: "AppUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domain");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropColumn(
                name: "AgentName",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "AgentPosition",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "BackgroundStyle",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "ButtonSize",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "ButtonStyle",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "CallToAction",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "GoogleAnalytics",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "Greeting",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "GreetingMessage",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "CustomizeButtons");

            migrationBuilder.DropColumn(
                name: "WidgetButtonImage",
                table: "CustomizeButtons");

            migrationBuilder.RenameColumn(
                name: "WidgetColor",
                table: "CustomizeButtons",
                newName: "BackgroundColor");

            migrationBuilder.RenameColumn(
                name: "Shadow",
                table: "CustomizeButtons",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "Opacity",
                table: "CustomizeButtons",
                newName: "Height");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
