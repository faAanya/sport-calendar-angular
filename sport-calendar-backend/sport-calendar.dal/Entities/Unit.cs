using System;
using System.Collections.Generic;

namespace sport_calendar.dal.Entities;

public partial class Unit
{
    public int Id { get; set; }

    public string UnitCode { get; set; } = null!;

    public virtual ICollection<WorkoutGoal> WorkoutGoals { get; set; } = new List<WorkoutGoal>();

    public virtual ICollection<WorkoutMetric> WorkoutMetrics { get; set; } = new List<WorkoutMetric>();
}
