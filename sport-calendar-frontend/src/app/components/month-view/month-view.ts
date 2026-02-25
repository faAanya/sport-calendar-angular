import { Component, effect, inject, input, InputSignal, OnInit } from '@angular/core';
import { Exercise } from '../../services/exercise';
import { DatePipe } from '@angular/common';
import { Workout } from '../exercise/exercise';
import { AddWorkoutModal } from '../modals/add-workout-modal/add-workout-modal';
import { WorkoutModel } from '../../models/workout.model';

@Component({
  selector: 'app-month-view',
  imports: [DatePipe, Workout, AddWorkoutModal],
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
    
    const year = day.getFullYear();
    const month = String(day.getMonth() + 1).padStart(2, '0');
    const dayStr = String(day.getDate()).padStart(2, '0');
    const formattedDate = `${year}-${month}-${dayStr}`;

    this.exerciseService.getExercisesByDate(formattedDate).subscribe({
      next: (data) => {
        this.selectedDateWorkouts = data;
        console.log('Workouts for selected date:', this.selectedDateWorkouts);
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

  hasEvents(day: Date): boolean {
    const dateString = day.toISOString().split('T')[0];
    return !!this.exercises[dateString]?.length;
  }

  isToday(date: Date): boolean {
  const today = new Date();
  return date.getDate() === today.getDate() &&
         date.getMonth() === today.getMonth() &&
         date.getFullYear() === today.getFullYear();
  }

  openAddModal(date?: Date) {
    if (date) {
      this.selectedDate = date; 
    }
    if (this.selectedDate) {
      this.isAddModalOpen = true;
    }
  }

  closeAddModal() {
    this.isAddModalOpen = false;
  }

  onWorkoutSaved(workoutData: any) {
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
        // TODO: Reload calendar data to reflect the new addition
      },
      error: (err) => console.error('Failed to create workout:', err)
    });
  }
  removeEvent(arg0: Date,arg1: any) {
    throw new Error('Method not implemented.');
  } 
}
