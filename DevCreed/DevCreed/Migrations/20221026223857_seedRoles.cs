﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevCreed.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[]
                {
                    "Id","Name","NormalizedName","ConcurrencyStamp"
                },
                values: new[]
                {
                    Guid.NewGuid().ToString(),"Admin","Admin".ToUpper(),Guid.NewGuid().ToString()
                });
            migrationBuilder.InsertData(
    table: "AspNetRoles",
    columns: new[]
    {
                    "Id","Name","NormalizedName","ConcurrencyStamp"
    },
    values: new[]
    {
                    Guid.NewGuid().ToString(),"Student","Student".ToUpper(),Guid.NewGuid().ToString()
    });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [AspNetRoles]");
        }
    }
}
