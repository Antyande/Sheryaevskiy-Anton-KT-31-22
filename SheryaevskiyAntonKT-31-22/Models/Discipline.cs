namespace SheryaevskiyAntonKT_31_22.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Workload> Workloads { get; set; }

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        // конект с нагрузкой


    }
}
