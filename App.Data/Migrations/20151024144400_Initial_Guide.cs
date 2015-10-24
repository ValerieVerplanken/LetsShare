using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace App.Data.Migrations
{
    public partial class Initial_Guide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", isNullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", isNullable: true),
                    Description = table.Column<string>(isNullable: true),
                    Offers = table.Column<string>(type: "nvarchar(1024)", isNullable: false),
                    Requests = table.Column<string>(type: "nvarchar(1024)", isNullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guide", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Guides");
        }
    }
}
