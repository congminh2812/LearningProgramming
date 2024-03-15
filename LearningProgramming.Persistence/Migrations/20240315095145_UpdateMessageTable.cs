using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningProgramming.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created_date",
                schema: "app-service",
                table: "messages",
                newName: "created_at");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "app-service",
                table: "messages",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "app-service",
                table: "messages");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "app-service",
                table: "messages",
                newName: "created_date");
        }
    }
}
