using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsAPI.Migrations
{
    public partial class FixRelationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Master_ApplicationForIncome_Master_FraternityConfiguration_EntityCodeFraternity",
                table: "Master_ApplicationForIncome");

            migrationBuilder.DropIndex(
                name: "IX_Master_ApplicationForIncome_EntityCodeFraternity",
                table: "Master_ApplicationForIncome");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Master_FraternityConfiguration",
                table: "Master_FraternityConfiguration");

            migrationBuilder.RenameTable(
                name: "Master_FraternityConfiguration",
                newName: "Master_Fraternity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Master_Fraternity",
                table: "Master_Fraternity",
                column: "EntityCode");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Master_ApplicationForIncome_Master_Fraternity_EntityCodeFraternity",
                table: "Master_ApplicationForIncome");

            migrationBuilder.DropIndex(
                name: "IX_Master_ApplicationForIncome_EntityCodeFraternity",
                table: "Master_ApplicationForIncome");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Master_Fraternity",
                table: "Master_Fraternity");

            migrationBuilder.RenameTable(
                name: "Master_Fraternity",
                newName: "Master_FraternityConfiguration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Master_FraternityConfiguration",
                table: "Master_FraternityConfiguration",
                column: "EntityCode");

            migrationBuilder.CreateIndex(
                name: "IX_Master_ApplicationForIncome_EntityCodeFraternity",
                table: "Master_ApplicationForIncome",
                column: "EntityCodeFraternity");

            migrationBuilder.AddForeignKey(
                name: "FK_Master_ApplicationForIncome_Master_FraternityConfiguration_EntityCodeFraternity",
                table: "Master_ApplicationForIncome",
                column: "EntityCodeFraternity",
                principalTable: "Master_FraternityConfiguration",
                principalColumn: "EntityCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
