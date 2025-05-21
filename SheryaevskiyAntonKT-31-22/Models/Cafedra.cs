namespace SheryaevskiyAntonKT_31_22.Models
{
    public class Cafedra
    {
        public int CafedraId { get; set; }
        public string CafedraName { get; set; }
        public int AdminId { get; set; }
        public DateTime Dataosnovania { get; set; }
        public Teacher Boss { get; internal set; }
    }
}
