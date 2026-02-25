using Microsoft.EntityFrameworkCore;
using sport_calendar.dal.Entities;

namespace sport_calendar.dal.Context;

public partial class ExerciseDbContext : DbContext
{
    public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityType> ActivityTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<WorkoutGoal> WorkoutGoals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activity__3213E83F71BBA419");

            entity.ToTable("activity_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__statuses__3213E83F30F9A01E");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusLabel)
                .HasMaxLength(30)
                .HasColumnName("status_label");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__units__3213E83F59CECF32");

            entity.ToTable("units");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UnitCode)
                .HasMaxLength(20)
                .HasColumnName("unit_code");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workouts__3213E83FE82A5192");

            entity.ToTable("workouts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.WorkoutDate).HasColumnName("workout_date");

            entity.HasOne(d => d.Activity).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Workouts_Activity");

            entity.HasOne(d => d.Status).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Workouts_Status");
        });

        modelBuilder.Entity<WorkoutGoal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workout___3213E83F9E883FD9");

            entity.ToTable("workout_goals");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TargetValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("target_value");
            entity.Property(e => e.CurrentValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("current_value");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.WorkoutId).HasColumnName("workout_id");

            entity.HasOne(d => d.Unit).WithMany(p => p.WorkoutGoals)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goals_Unit");

            entity.HasOne(d => d.Workout).WithMany(p => p.WorkoutGoals)
                .HasForeignKey(d => d.WorkoutId)
                .HasConstraintName("FK_Goals_Workout");
        });
        
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1, StatusLabel = "Planned" },
            new Status { Id = 2, StatusLabel = "In Progress" },
            new Status { Id = 3, StatusLabel = "Completed" }
        );

        modelBuilder.Entity<Unit>().HasData(
            new Unit { Id = 1, UnitCode = "steps" },
            new Unit { Id = 2, UnitCode = "km" },
            new Unit { Id = 3, UnitCode = "min" },
            new Unit { Id = 4, UnitCode = "reps" }
        );
        
        modelBuilder.Entity<ActivityType>().HasData(
            new ActivityType { Id = 1, Name = "Walking" },
            new ActivityType { Id = 2, Name = "Running" },
            new ActivityType { Id = 3, Name = "Cycling" },
            new ActivityType { Id = 4, Name = "Push-ups" },
            new ActivityType { Id = 5, Name = "Swimming" }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
