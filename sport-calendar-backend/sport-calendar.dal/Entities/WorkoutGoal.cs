namespace sport_calendar.dal.Entities;

public partial class WorkoutGoal
{
    public int Id { get; set; }

    public int WorkoutId { get; set; }

    public int UnitId { get; set; }

    public decimal TargetValue { get; set; }
    public decimal CurrentValue { get; set; } = 0;
    public virtual Unit? Unit { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Workout? Workout { get; set; } = null!;
}