import { Component, effect, input, InputSignal, OnInit } from '@angular/core';
import { Exercise } from '../../services/exercise';
import { DatePipe } from '@angular/common';
import { ExerciseList } from '../exercise-list/exercise-list';

@Component({
  selector: 'app-month-view',
  imports: [DatePipe,ExerciseList],
  templateUrl: './month-view.html',
  styleUrl: './month-view.css',
})
export class MonthView implements OnInit {
  
  date = input<Date>(new Date())
  days: Date[] = []
  exercises: {[key: string]: string[]} = {}
  selectedDate: Date | null = null

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

  selectDate(day: Date){
    this.selectedDate = day;
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
    this.days.forEach((day) => {
            const dateString = day.toISOString().split('T')[0];
            this.exercises[dateString] = this.exerciseService.getExercises(dateString);
        });
  }

  checkEvent(day: Date) {
        const dateString = day.toISOString().split('T')[0];
        const arr = this.exerciseService.getExercises(dateString);
        return arr.length;
    }
}
