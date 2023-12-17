using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 7, 60, 45, 190, 48, 250, 61, 43, 39, 191, 214, 197, 114, 104, 193, 253, 167, 172, 206, 235, 142, 245, 175, 154, 17, 57, 157, 14, 149, 22, 229, 120, 219, 221, 93, 196, 121, 255, 239, 0, 10, 37, 221, 13, 10, 185, 83, 73, 169, 39, 74, 76, 59, 240, 99, 202, 31, 115, 188, 181, 138, 126, 11, 145 }, new byte[] { 147, 189, 219, 54, 145, 196, 152, 71, 229, 55, 203, 8, 24, 124, 92, 145, 151, 232, 249, 43, 122, 58, 186, 36, 203, 135, 45, 208, 17, 164, 5, 124, 69, 17, 254, 178, 37, 93, 223, 75, 121, 18, 229, 202, 169, 203, 196, 134, 168, 31, 144, 192, 222, 216, 115, 113, 181, 230, 183, 66, 15, 46, 193, 171, 241, 54, 178, 33, 194, 251, 50, 91, 64, 157, 210, 62, 110, 8, 5, 164, 105, 14, 60, 183, 184, 49, 233, 0, 36, 149, 175, 206, 64, 241, 149, 202, 91, 221, 34, 18, 142, 244, 0, 190, 99, 150, 157, 84, 152, 87, 119, 125, 109, 25, 94, 40, 20, 148, 71, 76, 0, 192, 145, 109, 106, 160, 51, 7 } });

            migrationBuilder.CreateIndex(
                name: "IX_AiReports_ReportId",
                table: "AiReports",
                column: "ReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AiReports_Reports_ReportId",
                table: "AiReports",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AiReports_Reports_ReportId",
                table: "AiReports");

            migrationBuilder.DropIndex(
                name: "IX_AiReports_ReportId",
                table: "AiReports");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 23, 64, 155, 20, 150, 183, 148, 29, 163, 105, 227, 242, 26, 157, 75, 70, 246, 126, 80, 74, 173, 106, 87, 49, 50, 172, 109, 22, 135, 133, 248, 159, 193, 138, 121, 115, 139, 234, 200, 188, 125, 0, 161, 154, 79, 144, 26, 133, 161, 214, 224, 224, 116, 119, 208, 70, 148, 12, 118, 91, 160, 229, 128, 204 }, new byte[] { 132, 248, 52, 206, 193, 245, 39, 238, 61, 237, 103, 225, 106, 120, 7, 150, 215, 216, 228, 184, 229, 125, 249, 227, 70, 34, 35, 20, 198, 232, 78, 185, 7, 129, 90, 137, 81, 192, 72, 229, 170, 153, 209, 220, 132, 224, 155, 15, 251, 254, 235, 10, 14, 28, 17, 47, 218, 159, 107, 127, 16, 72, 117, 102, 208, 103, 66, 207, 246, 207, 220, 115, 171, 218, 152, 146, 82, 124, 121, 191, 117, 20, 193, 191, 207, 83, 90, 168, 104, 137, 177, 91, 217, 95, 8, 65, 33, 12, 132, 215, 182, 93, 111, 8, 175, 145, 17, 73, 48, 212, 84, 93, 25, 13, 132, 250, 32, 180, 143, 95, 33, 149, 204, 15, 88, 155, 74, 192 } });
        }
    }
}
