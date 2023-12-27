﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleBuzz.Migrations
{
    public partial class AddedPhoneInContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ContactMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ContactMedias");
        }
    }
}
