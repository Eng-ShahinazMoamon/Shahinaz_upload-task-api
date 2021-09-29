using Microsoft.EntityFrameworkCore.Migrations;

namespace uploud_task_api.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FileDetailEntity_DocumentTitle",
                table: "FileDetailEntity",
                column: "DocumentTitle",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FileDetailEntity_DocumentTitle",
                table: "FileDetailEntity");
        }
    }
}
