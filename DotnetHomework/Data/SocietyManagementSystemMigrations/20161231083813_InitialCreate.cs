using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetHomework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Society = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Society = table.Column<int>(nullable: false),
                    User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocietyCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocietyCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Society",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Category = table.Column<int>(nullable: false),
                    Creator = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Society", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TakePart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Activity = table.Column<int>(nullable: false),
                    User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakePart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VSocietyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Category = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    CreatorName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VSocietyInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "SocietyCategory");

            migrationBuilder.DropTable(
                name: "Society");

            migrationBuilder.DropTable(
                name: "TakePart");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "VSocietyInfo");
        }
    }
}
