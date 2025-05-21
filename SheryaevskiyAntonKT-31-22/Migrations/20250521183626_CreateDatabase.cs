using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheryaevskiyAntonKT_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    AcademicDegree_id = table.Column<int>(type: "int", nullable: false, comment: "Id Степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicDegree_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Название степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_AcademicDegree_AcademicDegree_id", x => x.AcademicDegree_id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id_position = table.Column<int>(type: "int", nullable: false, comment: "ID должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    positionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Positions_posinion_id", x => x.id_position);
                });

            migrationBuilder.CreateTable(
                name: "Cafedras",
                columns: table => new
                {
                    cafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Id Кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cafedra_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Название кафедры"),
                    boss_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор заведующего кафедры"),
                    date_osnovania = table.Column<byte[]>(type: "timestamp", nullable: false, comment: "Дата основания")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Cafedras_cafedra_id", x => x.cafedra_id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Disciplines_id = table.Column<int>(type: "int", nullable: false, comment: "Id дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disciplines_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Название дисциплины"),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Disciplines_disciplines_id", x => x.Disciplines_id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id_Teacher = table.Column<int>(type: "int", nullable: false, comment: "Id преподавателей")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_firstname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Имя преподавателя"),
                    Teacher_lastname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Отчество преподавателя"),
                    Teacher_midname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Фамилия преподавателя"),
                    Teacher_digreeId = table.Column<int>(type: "int", nullable: true, comment: "Степень преподавателя"),
                    Teacher_positionId = table.Column<int>(type: "int", nullable: true, comment: "Должность преподавателя"),
                    Teacher_cafedraId = table.Column<int>(type: "int", nullable: false, comment: "Кафедра преподавателя"),
                    WorkloadId = table.Column<int>(type: "int", nullable: true),
                    WorkloadId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Teachers_Teachers_id", x => x.id_Teacher);
                    table.ForeignKey(
                        name: "fk_cafedra_id",
                        column: x => x.Teacher_cafedraId,
                        principalTable: "Cafedras",
                        principalColumn: "cafedra_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_degree_id",
                        column: x => x.Teacher_digreeId,
                        principalTable: "Degrees",
                        principalColumn: "AcademicDegree_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_position_id",
                        column: x => x.Teacher_positionId,
                        principalTable: "Positions",
                        principalColumn: "id_position",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workload",
                columns: table => new
                {
                    lesson_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор занятия")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор предмета"),
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    workload_hours = table.Column<int>(type: "int", nullable: false, comment: "Нагрузка в часах")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Workload_Id", x => x.lesson_id);
                    table.ForeignKey(
                        name: "fk_TeacherId_id",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "id_Teacher",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "Disciplines",
                        principalColumn: "Disciplines_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "idx_Cafedras_fk_boss_id_prepod_id",
                table: "Cafedras",
                column: "cafedra_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cafedras_boss_id",
                table: "Cafedras",
                column: "boss_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherId",
                table: "Disciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "idx_Teachers_fk_cafedra_id",
                table: "Teachers",
                column: "Teacher_cafedraId");

            migrationBuilder.CreateIndex(
                name: "idx_Teachers_fk_degree_id",
                table: "Teachers",
                column: "Teacher_digreeId");

            migrationBuilder.CreateIndex(
                name: "idx_Teachers_fk_position_id",
                table: "Teachers",
                column: "Teacher_positionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_WorkloadId1",
                table: "Teachers",
                column: "WorkloadId1");

            migrationBuilder.CreateIndex(
                name: "idx_Workload_fk_subject_id",
                table: "Workload",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx_Workload_fk_TeacherId_id",
                table: "Workload",
                column: "teacher_id");

            migrationBuilder.AddForeignKey(
                name: "fk_boss_id_prepod_id",
                table: "Cafedras",
                column: "boss_id",
                principalTable: "Teachers",
                principalColumn: "id_Teacher",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "id_Teacher");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Workload_WorkloadId1",
                table: "Teachers",
                column: "WorkloadId1",
                principalTable: "Workload",
                principalColumn: "lesson_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_boss_id_prepod_id",
                table: "Cafedras");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "fk_TeacherId_id",
                table: "Workload");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Workload");

            migrationBuilder.DropTable(
                name: "Cafedras");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Disciplines");
        }
    }
}
