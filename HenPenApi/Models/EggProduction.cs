namespace HenPenApi.Models
{
    public class EggProduction
    {
        public int EggProductionId { get; set; } // Primary Key
        public int HenId { get; set; }
        public DateTime Date { get; set; }
        public int EggsCollected { get; set; }
        public Hen? Hen { get; set; }
    }
}
