using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainerDiets",
                columns: table => new
                {
                    TrainerDietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerDiets", x => x.TrainerDietId);
                    table.ForeignKey(
                        name: "FK_TrainerDiets_DietLists_DietListId",
                        column: x => x.DietListId,
                        principalTable: "DietLists",
                        principalColumn: "DietListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerExercises",
                columns: table => new
                {
                    TrainerExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerExercises", x => x.TrainerExerciseId);
                    table.ForeignKey(
                        name: "FK_TrainerExercises_ExercisesLists_ExerciseListId",
                        column: x => x.ExerciseListId,
                        principalTable: "ExercisesLists",
                        principalColumn: "ExerciseListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerDiets_DietListId",
                table: "TrainerDiets",
                column: "DietListId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerExercises_ExerciseListId",
                table: "TrainerExercises",
                column: "ExerciseListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerDiets");

            migrationBuilder.DropTable(
                name: "TrainerExercises");
        }
    }
}
