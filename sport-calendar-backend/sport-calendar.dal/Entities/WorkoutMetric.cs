namespace sport_calendar.dal.Entities;

public partial class WorkoutMetric
{
    public int Id { get; set; }

    public int WorkoutId { get; set; }

    public int UnitId { get; set; }

    public decimal MetricValue { get; set; }

    public DateTime? RecordedAt { get; set; }

    public virtual Unit Unit { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Workout Workout { get; set; } = null!;
}
