using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultipleTenancyTest.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionString",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "DatabaseName",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Host",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Tenants");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tenants",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionString",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DatabaseName",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
