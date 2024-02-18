using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearningProgramming.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "identity-service",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "identity-service",
                newName: "Users",
                newSchema: "identity-service");

            migrationBuilder.RenameColumn(
                name: "password",
                schema: "identity-service",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                schema: "identity-service",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "identity-service",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "identity-service",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                schema: "identity-service",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "identity-service",
                table: "Users",
                column: "id");

            migrationBuilder.CreateTable(
                name: "NavigationMenus",
                schema: "identity-service",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationMenus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "identity-service",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NavigationMenuRoles",
                schema: "identity-service",
                columns: table => new
                {
                    NavigationMenuId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationMenuRoles", x => new { x.NavigationMenuId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_NavigationMenuRoles_NavigationMenus_NavigationMenuId",
                        column: x => x.NavigationMenuId,
                        principalSchema: "identity-service",
                        principalTable: "NavigationMenus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavigationMenuRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity-service",
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "identity-service",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity-service",
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity-service",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavigationMenuRoles_RoleId",
                schema: "identity-service",
                table: "NavigationMenuRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "identity-service",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavigationMenuRoles",
                schema: "identity-service");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "identity-service");

            migrationBuilder.DropTable(
                name: "NavigationMenus",
                schema: "identity-service");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "identity-service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "identity-service",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "identity-service",
                newName: "users",
                newSchema: "identity-service");

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "identity-service",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "identity-service",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "identity-service",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "identity-service",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "identity-service",
                table: "users",
                newName: "first_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "identity-service",
                table: "users",
                column: "Id");
        }
    }
}
