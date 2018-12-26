using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.API.Migrations
{
    public partial class Testmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeadStatus_AspNetUsers_CreatedById",
                table: "LeadStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadStatus_AspNetUsers_UpdatedById",
                table: "LeadStatus");

            migrationBuilder.DropIndex(
                name: "IX_LeadStatus_CreatedById",
                table: "LeadStatus");

            migrationBuilder.DropIndex(
                name: "IX_LeadStatus_UpdatedById",
                table: "LeadStatus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "LeadStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "LeadStatus");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "LeadStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "LeadStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "LeadStatus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LeadStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "LeadStatus",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LeadStatus");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "LeadStatus");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "LeadStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LeadStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "LeadStatus");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "LeadStatus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "LeadStatus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeadStatus_CreatedById",
                table: "LeadStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LeadStatus_UpdatedById",
                table: "LeadStatus",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_LeadStatus_AspNetUsers_CreatedById",
                table: "LeadStatus",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeadStatus_AspNetUsers_UpdatedById",
                table: "LeadStatus",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
