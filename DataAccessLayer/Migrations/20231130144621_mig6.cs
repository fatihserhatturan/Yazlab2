using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "TrainerExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "TrainerDiets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainerExercises_TrainerId",
                table: "TrainerExercises",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerDiets_TrainerId",
                table: "TrainerDiets",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerDiets_Trainers_TrainerId",
                table: "TrainerDiets",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerExercises_Trainers_TrainerId",
                table: "TrainerExercises",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerDiets_Trainers_TrainerId",
                table: "TrainerDiets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerExercises_Trainers_TrainerId",
                table: "TrainerExercises");

            migrationBuilder.DropIndex(
                name: "IX_TrainerExercises_TrainerId",
                table: "TrainerExercises");

            migrationBuilder.DropIndex(
                name: "IX_TrainerDiets_TrainerId",
                table: "TrainerDiets");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "TrainerExercises");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "TrainerDiets");
        }
    }
}
