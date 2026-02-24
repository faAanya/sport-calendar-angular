using System;
using System.Collections.Generic;

namespace sport_calendar.dal.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string StatusLabel { get; set; } = null!;

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
