﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meal_plan_generator.Migrations
{
    public partial class forms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrient_NutrientSettings_PrioritySettingsId",
                table: "Nutrient");

            migrationBuilder.DropTable(
                name: "NutrientData");

            migrationBuilder.DropColumn(
                name: "CurrentNutrientQuantity",
                table: "Nutrient");

            migrationBuilder.DropColumn(
                name: "IdealAmount",
                table: "Nutrient");

            migrationBuilder.DropColumn(
                name: "MaxAmount",
                table: "Nutrient");

            migrationBuilder.DropColumn(
                name: "MinAmount",
                table: "Nutrient");

            migrationBuilder.RenameColumn(
                name: "PrioritySettingsId",
                table: "Nutrient",
                newName: "SettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_Nutrient_PrioritySettingsId",
                table: "Nutrient",
                newName: "IX_Nutrient_SettingsId");

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "NutrientSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "IdealAmount",
                table: "NutrientSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Intercept",
                table: "NutrientSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "LowerBound",
                table: "NutrientSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "NutrientSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "NutrientSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "UpperBound",
                table: "NutrientSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "NutrientSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "Nutrient",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_NutrientSettings_FormId",
                table: "NutrientSettings",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrient_NutrientSettings_SettingsId",
                table: "Nutrient",
                column: "SettingsId",
                principalTable: "NutrientSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientSettings_Forms_FormId",
                table: "NutrientSettings",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrient_NutrientSettings_SettingsId",
                table: "Nutrient");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientSettings_Forms_FormId",
                table: "NutrientSettings");

            migrationBuilder.DropIndex(
                name: "IX_NutrientSettings_FormId",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "IdealAmount",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "Intercept",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "LowerBound",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "UpperBound",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "NutrientSettings");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Nutrient");

            migrationBuilder.RenameColumn(
                name: "SettingsId",
                table: "Nutrient",
                newName: "PrioritySettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_Nutrient_SettingsId",
                table: "Nutrient",
                newName: "IX_Nutrient_PrioritySettingsId");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentNutrientQuantity",
                table: "Nutrient",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IdealAmount",
                table: "Nutrient",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxAmount",
                table: "Nutrient",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinAmount",
                table: "Nutrient",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "NutrientData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    IdealAmount = table.Column<float>(type: "real", nullable: false),
                    LowerBound = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpperBound = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutrientData_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NutrientData_FormId",
                table: "NutrientData",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrient_NutrientSettings_PrioritySettingsId",
                table: "Nutrient",
                column: "PrioritySettingsId",
                principalTable: "NutrientSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
