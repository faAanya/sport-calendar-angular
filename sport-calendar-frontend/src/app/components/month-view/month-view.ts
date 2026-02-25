import { ChangeDetectorRef, Component, effect, inject, input, InputSignal, OnInit } from '@angular/core';
import { Exercise } from '../../services/exercise';
import { DatePipe } from '@angular/common';
import { AddWorkoutModal } from '../modals/add-workout-modal/add-workout-modal';
import { WorkoutModel } from '../../models/workout.model';

@Component({
  selector: 'app-month-view',
  imports: [DatePipe, AddWorkoutModal],
  templateUrl: './month-view.html',
  styleUrl: './month-view.css',
})
export class MonthView implements OnInit {

  date = input<Date>(new Date())
  days: Date[] = []
  exercises: { [key: string]: any[] } = {};
  selectedDate = new Date();
  selectedDateWorkouts: any[] = [];
  isAddModalOpen = false;
  private cdr = inject(ChangeDetectorRef);
  
  private exerciseService = inject(Exercise);
    constructor() {
      effect(()=>{
        this.days = this.getDaysInMonth()
      })
  }

  ngOnInit(): void {
    this.days = this.getDaysInMonth()
  }

  selectDate(day: Date) {
    this.selectedDate = day;
    
    const formattedDate = this.formatDate(day); 

    this.exerciseService.getExercisesByDate(formattedDate).subscribe({
      next: (data) => {
        this.selectedDateWorkouts = data;
        this.cdr.detectChanges(); 
      },
      error: (err) => console.error('Failed to fetch day details', err)
    });
  }

  getDaysInMonth(): Date[] {
   const days = [];
   const year = this.date().getFullYear();
   const month = this.date().getMonth();
   const numDays = new Date(year, month + 1, 0).getDate();

   for (let i = 1; i <= numDays; i++) {
      days.push(new Date(year, month, i));
   }

    return days;
  }

  isToday(date: Date): boolean {
  const today = new Date();
  return date.getDate() === today.getDate() &&
         date.getMonth() === today.getMonth() &&
         date.getFullYear() === today.getFullYear();
  }

  createWorkout(workoutData: any) {
    const dateObj = workoutData.date as Date;
    const formattedDate = new Date(dateObj.getTime() - (dateObj.getTimezoneOffset() * 60000))
                            .toISOString().split('T')[0];

    const newWorkout: WorkoutModel = {
      workoutDate: formattedDate,
      activityId: Number(workoutData.activityId),
      statusId: 1, 
      workoutGoals: [
        {
          unitId: Number(workoutData.unitId),
          targetValue: Number(workoutData.targetValue)
        }
      ]
    };

    this.exerciseService.createWorkout(newWorkout).subscribe({
      next: () => {
        this.closeAddModal();
        const dateKey = this.formatDate(this.selectedDate);
        
        this.exerciseService.getExercisesByDate(dateKey).subscribe({
          next: (freshData) => {
            this.selectedDateWorkouts = [...freshData];
          
            this.exercises = { 
              ...this.exercises, 
              [dateKey]: freshData 
            };
            
            this.cdr.detectChanges();
          }
        });
      },
      error: (err) => console.error('Failed to create workout:', err)
    });
  }
  removeWorkout(workoutId: number) {
    if (!confirm('Are you sure you want to delete this workout?')) {
      return;
    }

    this.exerciseService.deleteWorkout(workoutId).subscribe({
      next: () => {
        console.log(`Workout ${workoutId} deleted successfully.`);
       
        this.selectedDateWorkouts = this.selectedDateWorkouts.filter(w => w.id !== workoutId);
        
        if (this.selectedDate) {
          const dateKey = this.formatDate(this.selectedDate);
                            
          if (this.exercises[dateKey]) {
            this.exercises[dateKey] = this.exercises[dateKey].filter((w: any) => w.id !== workoutId);
          }
        }
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Failed to delete workout:', err);
        alert('Could not delete the workout. Please try again.');
      }
    });
  }

  openAddModal(date?: Date) {
    if (date) {
      this.selectedDate = date; 
    }
    if (this.selectedDate) {
      this.isAddModalOpen = true;
    }
  }
  openEditModal(workout: any) {
    const goal = workout.workoutGoals[0];
    const currentVal = goal.currentValue || 0;
    
    const input = window.prompt(
      `Update progress for ${workout.activity.name} (Target: ${goal.targetValue} ${goal.unit.unitCode}):`, 
      currentVal.toString()
    );
    
    if (input !== null && input.trim() !== "") {
      const newCurrentValue = parseFloat(input);
      
      if (isNaN(newCurrentValue) || newCurrentValue < 0 || newCurrentValue > goal.targetValue) {
        alert("Please enter a valid number between 0 and the target value.");
        return;
      }
      const progressRatio = newCurrentValue / goal.targetValue;
      let newStatusId = 1; 

      if (progressRatio >= 1) {
        newStatusId = 3; 
      } else if (progressRatio > 0) {
        newStatusId = 2; 
      } else {
        newStatusId = 1;
      }

      const updatedWorkout = {
        ...workout,
        statusId: newStatusId, 
        status: null,  
        workoutDate: workout.workoutDate.split('T')[0], 
        workoutGoals: [
          {
            ...goal,
            currentValue: newCurrentValue
          }
        ]
      };
      this.exerciseService.updateWorkout(workout.id, updatedWorkout).subscribe({
        next: () => {
          const dateKey = this.formatDate(this.selectedDate);
          this.exerciseService.getExercisesByDate(dateKey).subscribe(freshData => {
            this.selectedDateWorkouts = [...freshData];
            this.exercises = { ...this.exercises, [dateKey]: freshData };
            this.cdr.detectChanges();
          });
        },
        error: (err) => {
          console.error("Failed to update", err);
          alert("Failed to update progress. Check console for details.");
        }
      });
    }
  }

  closeAddModal() {
    this.isAddModalOpen = false;
  }
      
   formatDate(date: Date): string {
    return new Date(date.getTime() - (date.getTimezoneOffset() * 60000))
      .toISOString().split('T')[0];
  }

  getProgressPercentage(current: number | undefined, target: number): number {
    if (!current || target === 0) return 0;
    const percentage = (current / target) * 100;
    return Math.min(Math.round(percentage), 100); 
  }
}
