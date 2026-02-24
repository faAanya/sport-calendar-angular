using System;
using System.Collections.Generic;

namespace sport_calendar.dal.Entities;

public partial class Workout
{
    public int Id { get; set; }

    public DateOnly WorkoutDate { get; set; }

    public int ActivityId { get; set; }

    public int StatusId { get; set; }

    public virtual ActivityType Activity { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<WorkoutGoal> WorkoutGoals { get; set; } = new List<WorkoutGoal>();

    public virtual ICollection<WorkoutMetric> WorkoutMetrics { get; set; } = new List<WorkoutMetric>();
}
