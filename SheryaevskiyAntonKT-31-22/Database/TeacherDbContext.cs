using Microsoft.EntityFrameworkCore;
using SheryaevskiyAntonKT_31_22.Database.Configurations;
using SheryaevskiyAntonKT_31_22.Models;

namespace SheryaevskiyAntonKT_31_22.Database
{
    public class TeacherDbContext : DbContext
    {
        DbSet<Cafedra> Cafedras { get; set; }
        DbSet<Degrees> Degrees { get; set; }
        DbSet<Disciplines> Disciplines { get; set; }
        DbSet<Nagruzka> Nagruzkas { get; set; }
        DbSet<Positions> Positions { get; set; }
        DbSet<Prepods> Prepods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CafedraConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinesConfiguration());
            modelBuilder.ApplyConfiguration(new NagruzkaConfiguration());
            modelBuilder.ApplyConfiguration(new PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new PrepodsConfiguration());
        }
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {
        } 
    }
}
