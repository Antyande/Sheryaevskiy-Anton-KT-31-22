namespace SheryaevskiyAntonKT_31_22.Models
{
    public class Teacher
    {
        public int? TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public int? AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public int? CafedraId { get; set; }
        public Cafedra Cafedra { get; set; }

        public int? WorkloadId { get; set; }
        public Workload Workload { get; set; }
    }
}
