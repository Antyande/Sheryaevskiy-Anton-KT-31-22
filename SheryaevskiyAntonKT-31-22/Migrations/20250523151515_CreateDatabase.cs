using System;
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
                name: "cd_academic_degree",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Название ученой степени"),
                    f_deleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false, comment: "Флаг удаления"),
                    d_created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP", comment: "Дата создания"),
                    d_updated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP", comment: "Дата обновления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Название дисциплины"),
                    c_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Код дисциплины"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Название должности"),
                    f_deleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false, comment: "Флаг удаления записи"),
                    d_created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP", comment: "Дата создания записи"),
                    d_updated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP", comment: "Дата обновления записи")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Название кафедры"),
                    d_foundation = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Дата основания кафедры"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    f_head_id = table.Column<long>(type: "bigint", nullable: true, comment: "Идентификатор заведующего кафедрой")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Имя преподавателя"),
                    c_lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Фамилия преподавателя"),
                    c_middlename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Отчество преподавателя"),
                    d_birthdate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Дата рождения"),
                    d_hiredate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Дата приема на работу"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    f_department_id = table.Column<long>(type: "bigint", nullable: true, comment: "Ссылка на кафедру"),
                    f_position_id = table.Column<long>(type: "bigint", nullable: true, comment: "Ссылка на должность"),
                    f_degree_id = table.Column<long>(type: "bigint", nullable: true, comment: "Ссылка на ученую степень"),
                    DisciplineId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_cd_teacher_cd_discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "cd_discipline",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_cd_teacher_f_degree_id",
                        column: x => x.f_degree_id,
                        principalTable: "cd_academic_degree",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_cd_teacher_f_department_id",
                        column: x => x.f_department_id,
                        principalTable: "cd_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cd_teacher_f_position_id",
                        column: x => x.f_position_id,
                        principalTable: "cd_position",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher_workload",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор нагрузки")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    n_hours = table.Column<int>(type: "integer", nullable: true, comment: "Количество часов"),
                    n_semester = table.Column<int>(type: "integer", nullable: true, comment: "Семестр (1 или 2)"),
                    n_year = table.Column<int>(type: "integer", nullable: true, comment: "Год"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    f_teacher_id = table.Column<long>(type: "bigint", nullable: true, comment: "Ссылка на преподавателя"),
                    f_discipline_id = table.Column<long>(type: "bigint", nullable: true, comment: "Ссылка на дисциплину")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_workload_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_cd_teacher_workload_f_discipline_id",
                        column: x => x.f_discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cd_teacher_workload_f_teacher_id",
                        column: x => x.f_teacher_id,
                        principalTable: "cd_teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_f_head_id",
                table: "cd_department",
                column: "f_head_id",
                unique: true,
                filter: "[f_head_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_cd_position_name",
                table: "cd_position",
                column: "c_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_f_degree_id",
                table: "cd_teacher",
                column: "f_degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_f_department_id",
                table: "cd_teacher",
                column: "f_department_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_f_position_id",
                table: "cd_teacher",
                column: "f_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_DisciplineId",
                table: "cd_teacher",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_workload_teacher_discipline_unique",
                table: "cd_teacher_workload",
                columns: new[] { "f_teacher_id", "f_discipline_id", "n_semester", "n_year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_workload_f_discipline_id",
                table: "cd_teacher_workload",
                column: "f_discipline_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cd_department_f_head_id",
                table: "cd_department",
                column: "f_head_id",
                principalTable: "cd_teacher",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cd_department_f_head_id",
                table: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_teacher_workload");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_academic_degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
