using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsAPI.Migrations
{
    public partial class FixRelationTablesV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FraternityEntityCode",
                table: "Master_ApplicationForIncome",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Master_ApplicationForIncome_FraternityEntityCode",
                table: "Master_ApplicationForIncome",
                column: "FraternityEntityCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Master_ApplicationForIncome_Master_Fraternity_FraternityEntityCode",
                table: "Master_ApplicationForIncome",
                column: "FraternityEntityCode",
                principalTable: "Master_Fraternity",
                principalColumn: "EntityCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Master_ApplicationForIncome_Master_Fraternity_FraternityEntityCode",
                table: "Master_ApplicationForIncome");

            migrationBuilder.DropIndex(
                name: "IX_Master_ApplicationForIncome_FraternityEntityCode",
                table: "Master_ApplicationForIncome");

            migrationBuilder.DropColumn(
                name: "FraternityEntityCode",
                table: "Master_ApplicationForIncome");
        }
    }
}
