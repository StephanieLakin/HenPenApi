namespace HenPenApi.Models
{
    public class Hen
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Breed { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EggColor { get; set; } = string.Empty;
        public int WklyEggAvg { get; set; }
    }
}
