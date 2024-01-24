﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 69, 181, 205, 13, 86, 153, 152, 6, 185, 149, 80, 53, 237, 244, 94, 15, 76, 32, 58, 40, 155, 228, 196, 45, 79, 100, 215, 246, 165, 5, 17, 9, 96, 237, 242, 212, 169, 105, 98, 103, 229, 124, 228, 53, 108, 213, 0, 255, 99, 162, 170, 157, 101, 46, 110, 72, 172, 93, 164, 85, 232, 233, 107 }, new byte[] { 196, 4, 251, 5, 193, 133, 124, 113, 131, 149, 242, 175, 205, 54, 14, 229, 155, 82, 27, 191, 164, 218, 179, 137, 247, 237, 88, 46, 78, 31, 67, 207, 255, 16, 69, 8, 147, 82, 137, 29, 62, 28, 121, 77, 84, 87, 5, 232, 189, 214, 110, 179, 158, 160, 209, 238, 117, 88, 248, 123, 67, 158, 250, 95, 202, 1, 17, 96, 207, 126, 213, 18, 61, 205, 29, 24, 51, 37, 13, 137, 225, 252, 148, 86, 75, 134, 55, 12, 135, 237, 180, 191, 140, 108, 37, 71, 103, 130, 65, 88, 121, 143, 138, 27, 118, 177, 104, 253, 221, 42, 161, 31, 72, 164, 248, 18, 237, 251, 226, 130, 22, 141, 179, 27, 80, 209, 165, 218 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 27, 62, 239, 222, 51, 158, 118, 199, 153, 186, 50, 36, 25, 58, 158, 177, 203, 192, 39, 168, 132, 74, 179, 70, 20, 39, 226, 201, 210, 97, 141, 242, 118, 33, 152, 216, 1, 19, 122, 25, 152, 33, 181, 7, 125, 28, 104, 7, 154, 123, 107, 213, 218, 0, 9, 217, 117, 231, 184, 40, 50, 126, 80, 148 }, new byte[] { 218, 250, 68, 186, 101, 202, 49, 224, 229, 58, 254, 255, 2, 104, 65, 199, 108, 246, 82, 9, 225, 69, 219, 141, 125, 162, 248, 91, 111, 17, 63, 95, 9, 166, 44, 165, 230, 210, 245, 9, 197, 1, 204, 75, 236, 175, 140, 199, 21, 207, 80, 25, 48, 66, 50, 222, 222, 13, 34, 86, 204, 195, 200, 26, 64, 107, 186, 28, 84, 254, 131, 213, 216, 251, 56, 161, 120, 191, 99, 165, 213, 157, 153, 36, 41, 98, 50, 118, 3, 199, 239, 199, 150, 97, 119, 107, 237, 227, 155, 73, 250, 46, 16, 58, 69, 65, 234, 139, 220, 57, 234, 164, 106, 149, 248, 226, 136, 233, 0, 146, 103, 133, 108, 52, 199, 150, 47, 217 } });
        }
    }
}