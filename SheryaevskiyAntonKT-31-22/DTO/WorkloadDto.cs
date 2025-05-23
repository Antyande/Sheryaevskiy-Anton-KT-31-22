namespace SheryaevskiyAntonKT_31_22.DTO
{
    public class WorkloadDto
    {
        public int Hours { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        public DisciplineDto Discipline { get; set; }
    }
}
