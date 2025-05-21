using SheryaevskiyAntonKT_31_22.Database.Helpers;
using SheryaevskiyAntonKT_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SheryaevskiyAntonKT_31_22.Database.Configurations
{
    public class CafedrasConfiguration : IEntityTypeConfiguration<Cafedra>
    {

        public const string tableName = "Cafedras";
        public void Configure(EntityTypeBuilder<Cafedra> builder)
        {
            builder
                .HasKey(p => p.CafedraId)
                .HasName($"pk_{tableName}_cafedra_id");

            builder.Property(p => p.CafedraId)
                .ValueGeneratedOnAdd()
                .HasColumnName("cafedra_id")
                .HasComment("Id Кафедры");

            builder.Property(p => p.CafedraName)
                .IsRequired()
                .HasColumnName("cafedra_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название кафедры");

            builder.Property(p => p.Dataosnovania)
                .HasColumnName("date_osnovania")
                .HasColumnType(ColumnType.Date)
                .HasComment("Дата основания");

            builder.Property(c => c.AdminId)
                .IsRequired()
                .HasColumnName("boss_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор заведующего кафедры");

            builder.ToTable(tableName).HasOne(c => c.Boss)
                .WithOne()
                .HasForeignKey<Cafedra>(c => c.AdminId)
                .HasConstraintName("fk_boss_id_prepod_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(tableName)
                .HasIndex(p => p.CafedraId, $"idx_{tableName}_fk_boss_id_prepod_id");

            builder.Navigation(p => p.Boss).AutoInclude();

        }
    }
}
