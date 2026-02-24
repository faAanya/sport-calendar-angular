using System;
using System.Collections.Generic;

namespace sport_calendar.dal.Entities;

public partial class ActivityType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
