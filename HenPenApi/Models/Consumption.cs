namespace HenPenApi.Models
{
    public class Consumption
    {
        public int ConsumptionId { get; set; }
        public int HenId { get; set; }
        public int FeedId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public Hen? Hen { get; set; }
        public Feed? Feed { get; set; }
    }
}
