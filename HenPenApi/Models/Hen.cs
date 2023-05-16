using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HenPenApi.Models
{
    public class Hen
    {
        public int HenId { get; set; } // Primary Key                               
        public string? HenName { get; set; }
        public DateTime DOB { get; set; }
        public int Weight { get; set; }
        public string? Description { get; set; }
        public string? EggColor { get; set; }
        public int WklyEggAvg { get; set; }
        public bool HasHealthIssue { get; set; }
        public int HealthIssueId { get; set; }
        public HealthIssue? HealthIssue { get; set; }
        public string? Medications { get; set; }
        public string? Notes { get; set; }

        [Column(TypeName = "varchar(250)")]
        public Breed? Breed { get; set; }

    }
}
