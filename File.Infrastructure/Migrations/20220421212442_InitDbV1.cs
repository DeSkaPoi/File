using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace File.Infrastructure.Migrations
{
    public partial class InitDbV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    ObjectId = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "no picture in storage"),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    KeyWords = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    ContentType = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
