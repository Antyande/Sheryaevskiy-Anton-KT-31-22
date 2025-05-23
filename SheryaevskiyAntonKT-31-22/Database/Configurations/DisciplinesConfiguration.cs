using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SheryaevskiyAntonKT_31_22.Database.Helpers;
using SheryaevskiyAntonKT_31_22.Models;

namespace SheryaevskiyAntonKT_31_22.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.Id)
                .HasName($"pk_{TableName}_id");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType(ColumnType.Long)
                .ValueGeneratedOnAdd()
                .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_name")
                .HasColumnType($"{ColumnType.String}(200)")
                .HasMaxLength(200)
                .HasComment("Название дисциплины");

            builder.Property(p => p.Code)
                .IsRequired()
                .HasColumnName("c_code")
                .HasColumnType($"{ColumnType.String}(20)")
                .HasMaxLength(20)
                .HasComment("Код дисциплины");
        }
    }
}
