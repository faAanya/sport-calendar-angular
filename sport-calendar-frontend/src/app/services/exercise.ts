import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Exercise {
  private storageKey = 'exercises';
  exercises: {[key: string]: string[]} = {}

  constructor() {
    this.loadEvents();
  }
  loadEvents() {
   const storedEvents = localStorage.getItem(this.storageKey);
        if (storedEvents) {
            this.exercises = JSON.parse(storedEvents);
        }
  }
  
  getExercises(date: string): string[] {
    return this.exercises[date] || [];
  }
  
}
