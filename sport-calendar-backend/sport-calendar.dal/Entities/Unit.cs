using System;
using System.Collections.Generic;

namespace sport_calendar.dal.Entities;

public partial class Unit
{
    public int Id { get; set; }

    public string UnitCode { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<WorkoutGoal> WorkoutGoals { get; set; } = new List<WorkoutGoal>();
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<WorkoutMetric> WorkoutMetrics { get; set; } = new List<WorkoutMetric>();
}
