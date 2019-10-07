using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyMap.DataModel.Migrations
{
    public partial class AddRegionTableAndRelationshipToReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "WayPoint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vote",
                table: "WayPoint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MaxLatitude = table.Column<double>(nullable: false),
                    MaxLongitude = table.Column<double>(nullable: false),
                    MinLatitude = table.Column<double>(nullable: false),
                    MinLongitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentRegionId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Region_ParentRegionId",
                        column: x => x.ParentRegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WayPoint_RegionId",
                table: "WayPoint",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_ParentRegionId",
                table: "Region",
                column: "ParentRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WayPoint_Region_RegionId",
                table: "WayPoint",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WayPoint_Region_RegionId",
                table: "WayPoint");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropIndex(
                name: "IX_WayPoint_RegionId",
                table: "WayPoint");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "WayPoint");

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "WayPoint");
        }
    }
}
