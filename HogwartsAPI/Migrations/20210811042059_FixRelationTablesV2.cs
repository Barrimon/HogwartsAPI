using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsAPI.Migrations
{
    public partial class FixRelationTablesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Master_ApplicationForIncome_Master_Fraternity_EntityCodeFraternity",
                table: "Master_ApplicationForIncome");

            migrationBuilder.DropIndex(
                name: "IX_Master_ApplicationForIncome_EntityCodeFraternity",
                table: "Master_ApplicationForIncome");

            migrationBuilder.DropColumn(
                name: "EntityCodeFraternity",
                table: "Master_ApplicationForIncome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EntityCodeFraternity",
                table: "Master_ApplicationForIncome",
                type: "uniqueidentifier",
                maxLength: 50,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Master_ApplicationForIncome_EntityCodeFraternity",
                table: "Master_ApplicationForIncome",
                column: "EntityCodeFraternity",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Master_ApplicationForIncome_Master_Fraternity_EntityCodeFraternity",
                table: "Master_ApplicationForIncome",
                column: "EntityCodeFraternity",
                principalTable: "Master_Fraternity",
                principalColumn: "EntityCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
