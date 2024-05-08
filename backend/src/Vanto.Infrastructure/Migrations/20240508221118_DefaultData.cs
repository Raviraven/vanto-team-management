using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Vanto",
                table: "Teams",
                column: "Id",
                value: new Guid("869b0fd8-aeb0-4bee-af39-06d50fb6b3fc"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Vanto",
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("869b0fd8-aeb0-4bee-af39-06d50fb6b3fc"));
        }
    }
}
