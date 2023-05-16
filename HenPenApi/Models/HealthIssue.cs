namespace HenPenApi.Models
{
    public class HealthIssue
    {
        public int HealthIssueId { get; set; }
        public string? HealthIssueName { get; set; }
        public string? HandlingDirections { get; set; }
        public string? RecommendedMedications { get; set; }
    }
}
