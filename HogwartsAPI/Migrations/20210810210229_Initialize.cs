using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsAPI.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Master_FraternityConfiguration",
                columns: table => new
                {
                    EntityCode = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_FraternityConfiguration", x => x.EntityCode);
                });

            migrationBuilder.CreateTable(
                name: "Master_ApplicationForIncome",
                columns: table => new
                {
                    EntityCode = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    Identification = table.Column<int>(maxLength: 10, nullable: false),
                    Age = table.Column<int>(maxLength: 2, nullable: false),
                    EntityCodeFraternity = table.Column<Guid>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_ApplicationForIncome", x => x.EntityCode);
                    table.ForeignKey(
                        name: "FK_Master_ApplicationForIncome_Master_FraternityConfiguration_EntityCodeFraternity",
                        column: x => x.EntityCodeFraternity,
                        principalTable: "Master_FraternityConfiguration",
                        principalColumn: "EntityCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Master_ApplicationForIncome_EntityCodeFraternity",
                table: "Master_ApplicationForIncome",
                column: "EntityCodeFraternity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Master_ApplicationForIncome");

            migrationBuilder.DropTable(
                name: "Master_FraternityConfiguration");
        }
    }
}
