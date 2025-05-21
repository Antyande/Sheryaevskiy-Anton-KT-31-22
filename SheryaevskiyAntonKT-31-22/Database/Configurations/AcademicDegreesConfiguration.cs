using SheryaevskiyAntonKT_31_22.Database.Helpers;
using SheryaevskiyAntonKT_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SheryaevskiyAntonKT_31_22.Database.Configurations
{
    public class AcademicDegreesConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {

        public const string tableName = "AcademicDegree";
        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder
                .HasKey(p => p.AcademicDegreeId)
                .HasName($"pk_{tableName}_AcademicDegree_id");

            builder.Property(p => p.AcademicDegreeId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.AcademicDegreeId)
                .HasColumnName("AcademicDegree_id")
                .HasComment("Id Степени");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("AcademicDegree_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название степени");
        }
    }
}
