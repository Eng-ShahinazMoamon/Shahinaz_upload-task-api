using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace uploud_task_api.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileDetailEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTitle = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    DocumentDescription = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    DocumentURL = table.Column<string>(maxLength: 200, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetailEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDetailEntity");
        }
    }
}
