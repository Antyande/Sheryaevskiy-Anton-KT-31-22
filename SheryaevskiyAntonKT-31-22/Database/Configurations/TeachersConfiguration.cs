using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SheryaevskiyAntonKT_31_22.Database.Helpers;
using SheryaevskiyAntonKT_31_22.Models;

namespace SheryaevskiyAntonKT_31_22.Database.Configurations
{
    public class TeachersConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string tableName = "Teachers";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{tableName}_Teachers_id");

            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.TeacherId)
                .HasColumnName("id_Teacher")
                .HasComment("Id преподавателей");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("Teacher_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("Teacher_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("Teacher_midname")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.AcademicDegreeId)
                .HasColumnName("Teacher_digreeId")
                .HasColumnType(ColumnType.Int)
                .HasComment("Степень преподавателя");


            builder.ToTable(tableName)
                .HasOne(p => p.AcademicDegree)
                .WithMany()
                .HasForeignKey(p => p.AcademicDegreeId)
                .HasConstraintName("fk_degree_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(tableName)
                .HasIndex(p => p.AcademicDegreeId, $"idx_{tableName}_fk_degree_id");

            builder.Property(p => p.PositionId)
                .HasColumnName("Teacher_positionId")
                .HasColumnType(ColumnType.Int)
                .HasComment("Должность преподавателя");


            builder.ToTable(tableName)
                .HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PositionId)
                .HasConstraintName("fk_position_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(tableName)
                .HasIndex(p => p.PositionId, $"idx_{tableName}_fk_position_id");


            builder.Property(p => p.CafedraId)
                .IsRequired()
                .HasColumnName("Teacher_cafedraId")
                .HasColumnType(ColumnType.Int)
                .HasComment("Кафедра преподавателя");


            builder.ToTable(tableName)
                .HasOne(p => p.Cafedra)
                .WithMany()
                .HasForeignKey(p => p.CafedraId)
                .HasConstraintName("fk_cafedra_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(tableName)
                .HasIndex(p => p.CafedraId, $"idx_{tableName}_fk_cafedra_id");

            builder.Navigation(p => p.Cafedra).AutoInclude();
        }

    }
}
