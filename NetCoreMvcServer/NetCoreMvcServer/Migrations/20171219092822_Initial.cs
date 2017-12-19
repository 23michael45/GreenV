using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetCoreMvcServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_GroundTruthData",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    device = table.Column<string>(nullable: true),
                    timestamp = table.Column<long>(nullable: false),
                    leftright = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_GroundTruthData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "App_SensorData",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    device = table.Column<string>(nullable: true),
                    timestamps = table.Column<long>(nullable: false),
                    timestampms = table.Column<long>(nullable: false),
                    sendsorvalue = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_SensorData", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_GroundTruthData");

            migrationBuilder.DropTable(
                name: "App_SensorData");
        }
    }
}
