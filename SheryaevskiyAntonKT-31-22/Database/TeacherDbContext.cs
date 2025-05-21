using Microsoft.EntityFrameworkCore;
using SheryaevskiyAntonKT_31_22.Database.Configurations;
using SheryaevskiyAntonKT_31_22.Models;

namespace SheryaevskiyAntonKT_31_22.Database
{
    public class TeacherDbContext : DbContext
    {
        DbSet<Cafedra> Cafedras { get; set; }
        DbSet<AcademicDegree> Degrees { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Workload> Workload { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CafedrasConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreesConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinesConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
            modelBuilder.ApplyConfiguration(new PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new TeachersConfiguration());
        }
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {
        } 
    }
}
