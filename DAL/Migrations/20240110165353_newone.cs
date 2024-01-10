using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_DAL.Migrations
{
    /// <inheritdoc />
    public partial class newone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_SystemAppRoles_SystemAppRoleId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PermissionType",
                table: "Permissions");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.AlterColumn<Guid>(
                name: "SystemAppRoleId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_SystemAppRoles_SystemAppRoleId",
                table: "Permissions",
                column: "SystemAppRoleId",
                principalTable: "SystemAppRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_SystemAppRoles_SystemAppRoleId",
                table: "Permissions");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "Lastname");

            migrationBuilder.AlterColumn<Guid>(
                name: "SystemAppRoleId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PermissionType",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_SystemAppRoles_SystemAppRoleId",
                table: "Permissions",
                column: "SystemAppRoleId",
                principalTable: "SystemAppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
