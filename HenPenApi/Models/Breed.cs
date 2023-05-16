namespace HenPenApi.Models
{
    public class Breed
    {
        public int Id { get; set; } // Primary Key
        public string? Name { get; set;  }                            
        public string? Characteristics { get; set; } 
        public string? EggColor { get; set; } 
        public string? Climate { get; set; } 
        public string? Purpose { get; set; } 
        public List<Hen>? Hens { get; set; }
    }
}
