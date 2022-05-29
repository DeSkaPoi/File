﻿using System;
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

            migrationBuilder.CreateTable(
                name: "FileObject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileObject_Files_Id",
                        column: x => x.Id,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileObject");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}