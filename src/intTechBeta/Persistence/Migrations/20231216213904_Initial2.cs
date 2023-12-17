using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AiReports_Reports_ReportId",
                table: "AiReports");

            migrationBuilder.DropIndex(
                name: "IX_AiReports_ReportId",
                table: "AiReports");

            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "AiReports");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 23, 64, 155, 20, 150, 183, 148, 29, 163, 105, 227, 242, 26, 157, 75, 70, 246, 126, 80, 74, 173, 106, 87, 49, 50, 172, 109, 22, 135, 133, 248, 159, 193, 138, 121, 115, 139, 234, 200, 188, 125, 0, 161, 154, 79, 144, 26, 133, 161, 214, 224, 224, 116, 119, 208, 70, 148, 12, 118, 91, 160, 229, 128, 204 }, new byte[] { 132, 248, 52, 206, 193, 245, 39, 238, 61, 237, 103, 225, 106, 120, 7, 150, 215, 216, 228, 184, 229, 125, 249, 227, 70, 34, 35, 20, 198, 232, 78, 185, 7, 129, 90, 137, 81, 192, 72, 229, 170, 153, 209, 220, 132, 224, 155, 15, 251, 254, 235, 10, 14, 28, 17, 47, 218, 159, 107, 127, 16, 72, 117, 102, 208, 103, 66, 207, 246, 207, 220, 115, 171, 218, 152, 146, 82, 124, 121, 191, 117, 20, 193, 191, 207, 83, 90, 168, 104, 137, 177, 91, 217, 95, 8, 65, 33, 12, 132, 215, 182, 93, 111, 8, 175, 145, 17, 73, 48, 212, 84, 93, 25, 13, 132, 250, 32, 180, 143, 95, 33, 149, 204, 15, 88, 155, 74, 192 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "Reports");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "AiReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 155, 112, 92, 91, 164, 99, 167, 197, 109, 173, 151, 168, 236, 59, 170, 171, 71, 125, 200, 225, 131, 76, 169, 31, 174, 143, 69, 131, 161, 228, 184, 156, 27, 75, 216, 149, 136, 38, 74, 128, 56, 236, 204, 125, 87, 213, 145, 245, 26, 52, 8, 108, 95, 88, 83, 123, 198, 187, 199, 190, 222, 219, 241, 184 }, new byte[] { 197, 118, 146, 66, 216, 23, 65, 240, 48, 197, 128, 238, 22, 118, 132, 215, 195, 240, 119, 236, 160, 21, 38, 136, 126, 226, 65, 93, 32, 187, 157, 48, 158, 222, 53, 174, 61, 26, 188, 67, 12, 29, 163, 220, 205, 221, 242, 216, 79, 162, 180, 227, 67, 115, 16, 162, 152, 209, 192, 135, 85, 118, 233, 142, 200, 48, 244, 146, 35, 125, 248, 121, 249, 79, 23, 159, 96, 61, 28, 179, 238, 148, 220, 206, 214, 201, 147, 78, 176, 187, 82, 237, 158, 198, 160, 134, 227, 111, 251, 173, 50, 74, 37, 98, 117, 244, 193, 180, 132, 117, 186, 151, 165, 39, 93, 55, 162, 208, 213, 161, 211, 110, 97, 247, 46, 12, 162, 219 } });

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
    }
}
