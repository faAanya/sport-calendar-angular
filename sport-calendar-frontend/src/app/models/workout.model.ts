export interface WorkoutGoal {
  id?: number;
  workoutId?: number; 
  unitId: number;
  targetValue: number;
  currentValue?: number;
}

export interface WorkoutModel {
  id?: number; 
  workoutDate: string; 
  activityId: number;
  statusId: number;
  workoutGoals: WorkoutGoal[];
}