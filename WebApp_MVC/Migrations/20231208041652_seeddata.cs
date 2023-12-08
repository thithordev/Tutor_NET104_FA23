using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp_MVC.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "abc",
                table: "SanPham");

            migrationBuilder.InsertData(
                table: "DanhMuc",
                columns: new[] { "ID", "TenDanhMuc", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("35c0128c-cebd-4501-afc4-74a686be8018"), "Đồ ăn", 1 },
                    { new Guid("c031e6c3-4074-4236-ad30-3e83acd5b770"), "Quần áo", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "ID",
                keyValue: new Guid("35c0128c-cebd-4501-afc4-74a686be8018"));

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "ID",
                keyValue: new Guid("c031e6c3-4074-4236-ad30-3e83acd5b770"));

            migrationBuilder.AddColumn<string>(
                name: "abc",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
