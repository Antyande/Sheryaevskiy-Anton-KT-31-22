using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SheryaevskiyAntonKT_31_22.Database.Helpers;
using SheryaevskiyAntonKT_31_22.Models;

namespace SheryaevskiyAntonKT_31_22.Database.Configurations
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>

    {
        private const string TableName = "Workload";

        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder.HasKey(s => s.WorkloadId).HasName($"pk_{TableName}_Id");

            builder.Property(s => s.WorkloadId)
                .ValueGeneratedOnAdd()
                .HasColumnName("lesson_id")
                .HasComment("Идентификатор занятия");

            builder.Property(s => s.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор предмета");

            builder.ToTable(TableName).HasOne(s => s.Disciplines)
                .WithMany()
                .HasForeignKey(s => s.DisciplineId)
                .HasConstraintName($"fk_discipline_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.DisciplineId, $"idx_{TableName}_fk_subject_id");

            builder.Property(s => s.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор преподавателя");

            builder.ToTable(TableName).HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey(s => s.TeacherId)
                .HasConstraintName($"fk_TeacherId_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.TeacherId, $"idx_{TableName}_fk_TeacherId_id");

            builder.Property(s => s.Hours)
                .IsRequired()
                .HasColumnName("workload_hours")
                .HasColumnType(ColumnType.Int)
                .HasComment("Нагрузка в часах");

        }

    }
}
