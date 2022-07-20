using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit19072022.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoList_AspNetUsers_AspNetUserId",
                table: "ToDoList");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "ToDoList",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b5b0da-e61e-46ba-b766-e1acc7401352",
                column: "ConcurrencyStamp",
                value: "3d705705-2da9-4b78-82b3-b23008d3f135");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "badd4ddd-df0e-4621-af37-c2b36aaa6742",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c2b17fe-653b-4826-a13b-3cbf1c9c67a6", "AQAAAAEAACcQAAAAENurhD1QF0Ignw/sqBu9ddNxdoMWAr0rZ84nn55b/rve+j/jo2dS5ZU0lnNo16Ppmg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoList_AspNetUsers_AspNetUserId",
                table: "ToDoList",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoList_AspNetUsers_AspNetUserId",
                table: "ToDoList");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "badd4ddd-df0e-4621-af37-c2b36aaa6742");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "ToDoList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b5b0da-e61e-46ba-b766-e1acc7401352",
                column: "ConcurrencyStamp",
                value: "2be3cf6a-8442-40b4-8d35-a400ec1b6f7e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "badd4ddd-df0e-4621-af37-c2b36aaa6742", 0, "ed1b4f0b-431d-483c-80f9-14b5558a9f2f", "AspNetUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEC5aKgDSnGhESutPQVLZZCzgPo8GGUvwtVet+LMXlojW7xBYIooatF4Wc/64uiMo0A==", null, false, "c8c5cc23-1703-4984-8ac7-4b178d2d9982", false, "admin@admin.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoList_AspNetUsers_AspNetUserId",
                table: "ToDoList",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
