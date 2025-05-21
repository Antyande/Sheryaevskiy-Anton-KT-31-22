namespace SheryaevskiyAntonKT_31_22.Models
{
    public class Workload
    {
        public int? WorkloadId { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Disciplines { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int Hours { get; set; }
    }
}
