using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetHomework.Data.SocietyManagementSystemMigrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Society = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    EntryPost = table.Column<string>(nullable: true),
                    EntryTime = table.Column<DateTime>(nullable: true),
                    Society = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
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
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
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
                    Time = table.Column<DateTime>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakePart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VActivityInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    SocietyDescription = table.Column<string>(nullable: true),
                    SocietyId = table.Column<int>(nullable: false),
                    SocietyName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VActivityInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VMemberInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    EntryPost = table.Column<string>(nullable: true),
                    EntryTime = table.Column<DateTime>(nullable: true),
                    SocietyDescription = table.Column<string>(nullable: true),
                    SocietyId = table.Column<int>(nullable: false),
                    SocietyName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VMemberInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VSocietyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MemberCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VSocietyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VTakePartInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityDescription = table.Column<string>(nullable: true),
                    ActivityId = table.Column<int>(nullable: false),
                    ActivityName = table.Column<string>(nullable: true),
                    ActivityStatus = table.Column<string>(nullable: true),
                    ActivityTime = table.Column<DateTime>(nullable: true),
                    ApplicationPeriod = table.Column<DateTime>(nullable: true),
                    SocietyId = table.Column<int>(nullable: false),
                    SocietyName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VTakePartInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "SocietyCategory");

            migrationBuilder.DropTable(
                name: "Society");

            migrationBuilder.DropTable(
                name: "TakePart");

            migrationBuilder.DropTable(
                name: "VActivityInfo");

            migrationBuilder.DropTable(
                name: "VMemberInfo");

            migrationBuilder.DropTable(
                name: "VSocietyInfo");

            migrationBuilder.DropTable(
                name: "VTakePartInfo");
        }
    }
}
