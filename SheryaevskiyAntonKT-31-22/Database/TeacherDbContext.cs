using Microsoft.EntityFrameworkCore;
using SheryaevskiyAntonKT_31_22.Database.Configurations;
using SheryaevskiyAntonKT_31_22.Models;
using static SheryaevskiyAntonKT_31_22.Database.Configurations.AcademicDegreesConfiguration;

namespace SheryaevskiyAntonKT_31_22.Database
{
    public class TeacherDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<AcademicDegree> Degrees { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Workload> Workloads { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {
        } 
    }
}
