import { Component, input } from '@angular/core';

@Component({
  selector: 'app-exercise',
  imports: [],
  templateUrl: './exercise.html',
  styleUrl: './exercise.css',
})
export class Workout {
name = input.required<string>();
}
