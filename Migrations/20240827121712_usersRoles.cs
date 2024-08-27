using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellingProducts.Migrations
{
    /// <inheritdoc />
    public partial class usersRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5418ddd8-26c3-4b2f-b916-e8132f31af44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35447ac-c4b3-41f4-8d01-a58d7cb90733");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cd90e4f-f46a-4415-8c65-a7d6ed63357e", "37e80e77-ccbd-451f-ba98-986c9752d380", "Admin", "admin" },
                    { "50ef8fb3-ec6e-4767-b686-cb39c3f61533", "37ea1932-7858-41a2-98b5-d249f5b50b96", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cd90e4f-f46a-4415-8c65-a7d6ed63357e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50ef8fb3-ec6e-4767-b686-cb39c3f61533");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5418ddd8-26c3-4b2f-b916-e8132f31af44", "e7a704e0-5dc0-486c-b672-8138197a3680", "Admin", "admin" },
                    { "f35447ac-c4b3-41f4-8d01-a58d7cb90733", "9b3f8b79-1fe5-4652-99f0-8068ba08e824", "Admin", "admin" }
                });
        }
    }
}
