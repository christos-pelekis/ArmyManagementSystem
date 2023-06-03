using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmyManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToStaffMembersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "StaffMembers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "StaffMembers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColorOfEyes",
                table: "StaffMembers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColorOfHair",
                table: "StaffMembers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "StaffMembers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "StaffMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "StaffMembers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "ColorOfEyes",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "ColorOfHair",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "StaffMembers");

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "StaffMembers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
