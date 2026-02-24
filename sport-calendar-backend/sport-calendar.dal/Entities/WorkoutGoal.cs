using System;
using System.Collections.Generic;

namespace sport_calendar.dal.Entities;

public partial class WorkoutGoal
{
    public int Id { get; set; }

    public int WorkoutId { get; set; }

    public int UnitId { get; set; }

    public decimal TargetValue { get; set; }

    public virtual Unit Unit { get; set; } = null!;

    public virtual Workout Workout { get; set; } = null!;
}
