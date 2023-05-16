﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HenPenApi.Migrations
{
    /// <inheritdoc />
    public partial class updatebreeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Breeds",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Breeds");
        }
    }
}
