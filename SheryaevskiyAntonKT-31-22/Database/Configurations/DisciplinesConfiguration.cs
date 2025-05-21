using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SheryaevskiyAntonKT_31_22.Database.Helpers;
using SheryaevskiyAntonKT_31_22.Models;

namespace SheryaevskiyAntonKT_31_22.Database.Configurations
{
    public class DisciplinesConfiguration : IEntityTypeConfiguration<Discipline>
    {

        public const string tableName = "Disciplines";
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                .HasKey(p => p.DisciplineId)
                .HasName($"pk_{tableName}_disciplines_id");

            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DisciplineId)
                .HasColumnName("Disciplines_id")
                .HasComment("Id дисциплины");

            builder.Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("Disciplines_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название дисциплины");

        }
    }
}
