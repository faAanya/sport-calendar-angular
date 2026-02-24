import { Component, effect, input, InputSignal, OnInit } from '@angular/core';
import { Exercise } from '../../services/exercise';
import { DatePipe } from '@angular/common';
import { ExerciseList } from '../exercise-list/exercise-list';
import { Workout } from '../../exercise/exercise';

@Component({
  selector: 'app-month-view',
  imports: [DatePipe,ExerciseList, Workout],
  templateUrl: './month-view.html',
  styleUrl: './month-view.css',
})
export class MonthView implements OnInit {
  
  date = input<Date>(new Date())
  days: Date[] = []
  exercises: { [key: string]: any[] } = {};
  selectedDate: Date | null = null
  selectedDateWorkouts: any[] = [];

    constructor(private exerciseService: Exercise) {
      effect(()=>{
        this.days = this.getDaysInMonth()
        this.loadExercises();
      })
  }

removeEvent(date: Date, exercise: string) {
throw new Error('Method not implemented.');
}

addEvent(date: Date) {
throw new Error('Method not implemented.');
}

  ngOnInit(): void {
    this.days = this.getDaysInMonth()
    this.loadExercises();
  }

  selectDate(day: Date) {
    this.selectedDate = day;
    
    const year = day.getFullYear();
    const month = String(day.getMonth() + 1).padStart(2, '0');
    const dayStr = String(day.getDate()).padStart(2, '0');
    const formattedDate = `${year}-${month}-${dayStr}`;

    // Fetch details for this specific day
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

 loadExercises() {
    this.exerciseService.getExercises().subscribe(data => {
      const grouped: {[key: string]: any[]} = {};
      
      data.forEach(item => {
        
        const dateKey = item.workoutDate.split('T')[0]; 
        if (!grouped[dateKey]) grouped[dateKey] = [];
        grouped[dateKey].push(item);
      });
      
      this.exercises = grouped;
    });
  }

  // Clean up the unused checkEvent method or update it
  hasEvents(day: Date): boolean {
    const dateString = day.toISOString().split('T')[0];
    return !!this.exercises[dateString]?.length;
  }
}
