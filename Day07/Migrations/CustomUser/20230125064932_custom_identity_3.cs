using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day07.Migrations.CustomUser
{
    public partial class custom_identity_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetUserRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AspNetUserRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
