using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearningProgramming.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity-service");

            migrationBuilder.CreateTable(
                name: "navigation_menus",
                schema: "identity-service",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parent_id = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navigation_menus", x => x.id);
                    table.ForeignKey(
                        name: "FK_navigation_menus_navigation_menus_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "identity-service",
                        principalTable: "navigation_menus",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "identity-service",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "identity-service",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "navigation_menu_roles",
                schema: "identity-service",
                columns: table => new
                {
                    navigation_menu_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navigation_menu_roles", x => new { x.navigation_menu_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_navigation_menu_roles_navigation_menus_navigation_menu_id",
                        column: x => x.navigation_menu_id,
                        principalSchema: "identity-service",
                        principalTable: "navigation_menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_navigation_menu_roles_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "identity-service",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                schema: "identity-service",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    provider_key = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    login_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expires_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    refresh_token = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_logins", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_logins_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "identity-service",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                schema: "identity-service",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "identity-service",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "identity-service",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "identity-service",
                table: "navigation_menus",
                columns: new[] { "id", "created_at", "created_by", "icon", "is_deleted", "name", "parent_id", "position", "updated_at", "updated_by", "url" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 2, 25, 14, 2, 54, 65, DateTimeKind.Utc).AddTicks(7024), 1L, "dashboard", false, "Dashboard", null, 1, null, null, "/" },
                    { 2L, new DateTime(2024, 2, 25, 14, 2, 54, 65, DateTimeKind.Utc).AddTicks(7031), 1L, "user", false, "Users", null, 2, null, null, "/users" }
                });

            migrationBuilder.InsertData(
                schema: "identity-service",
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "description", "is_deleted", "name", "updated_at", "updated_by" },
                values: new object[] { 1L, new DateTime(2024, 2, 25, 14, 2, 54, 65, DateTimeKind.Utc).AddTicks(9517), 1L, "Admin management system", false, "Admin", null, null });

            migrationBuilder.InsertData(
                schema: "identity-service",
                table: "users",
                columns: new[] { "id", "created_at", "email", "first_name", "is_deleted", "last_name", "password", "updated_at" },
                values: new object[] { 1L, new DateTime(2024, 2, 25, 14, 2, 54, 66, DateTimeKind.Utc).AddTicks(1380), "admin@host.com", "Admin", false, "Web", "21232f297a57a5a743894a0e4a801fc3", null });

            migrationBuilder.InsertData(
                schema: "identity-service",
                table: "navigation_menu_roles",
                columns: new[] { "navigation_menu_id", "role_id" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L }
                });

            migrationBuilder.InsertData(
                schema: "identity-service",
                table: "navigation_menus",
                columns: new[] { "id", "created_at", "created_by", "icon", "is_deleted", "name", "parent_id", "position", "updated_at", "updated_by", "url" },
                values: new object[,]
                {
                    { 3L, new DateTime(2024, 2, 25, 14, 2, 54, 65, DateTimeKind.Utc).AddTicks(7032), 1L, null, false, "My profile", 2L, 1, null, null, "/users/profile" },
                    { 4L, new DateTime(2024, 2, 25, 14, 2, 54, 65, DateTimeKind.Utc).AddTicks(7037), 1L, null, false, "Create a new user", 2L, 2, null, null, "/users/create" },
                    { 5L, new DateTime(2024, 2, 25, 14, 2, 54, 65, DateTimeKind.Utc).AddTicks(7038), 1L, null, false, "Roles & permission", 2L, 3, null, null, "/users/roles-permission" }
                });

            migrationBuilder.InsertData(
                schema: "identity-service",
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                schema: "identity-service",
                table: "navigation_menu_roles",
                columns: new[] { "navigation_menu_id", "role_id" },
                values: new object[,]
                {
                    { 3L, 1L },
                    { 4L, 1L },
                    { 5L, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_navigation_menu_roles_role_id",
                schema: "identity-service",
                table: "navigation_menu_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_navigation_menus_parent_id",
                schema: "identity-service",
                table: "navigation_menus",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_logins_user_id",
                schema: "identity-service",
                table: "user_logins",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                schema: "identity-service",
                table: "user_roles",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "navigation_menu_roles",
                schema: "identity-service");

            migrationBuilder.DropTable(
                name: "user_logins",
                schema: "identity-service");

            migrationBuilder.DropTable(
                name: "user_roles",
                schema: "identity-service");

            migrationBuilder.DropTable(
                name: "navigation_menus",
                schema: "identity-service");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "identity-service");

            migrationBuilder.DropTable(
                name: "users",
                schema: "identity-service");
        }
    }
}
