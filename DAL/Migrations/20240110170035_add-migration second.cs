using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_DAL.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationsecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_SystemAppRoles_SystemAppRoleId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemAppRoles_SystemApps_SystemAppId",
                table: "SystemAppRoles");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_SystemAppRoleId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "SystemAppRoleId",
                table: "Permissions");

            migrationBuilder.AlterColumn<Guid>(
                name: "SystemAppId",
                table: "SystemAppRoles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemAppRoles_SystemApps_SystemAppId",
                table: "SystemAppRoles",
                column: "SystemAppId",
                principalTable: "SystemApps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemAppRoles_SystemApps_SystemAppId",
                table: "SystemAppRoles");

            migrationBuilder.AlterColumn<Guid>(
                name: "SystemAppId",
                table: "SystemAppRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SystemAppRoleId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_SystemAppRoleId",
                table: "Permissions",
                column: "SystemAppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_SystemAppRoles_SystemAppRoleId",
                table: "Permissions",
                column: "SystemAppRoleId",
                principalTable: "SystemAppRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemAppRoles_SystemApps_SystemAppId",
                table: "SystemAppRoles",
                column: "SystemAppId",
                principalTable: "SystemApps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
