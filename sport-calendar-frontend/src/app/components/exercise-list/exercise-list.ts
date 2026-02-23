import { Component, EventEmitter, input, output } from '@angular/core';

@Component({
  selector: 'app-exercise-list',
  imports: [],
  templateUrl: './exercise-list.html',
  styleUrl: './exercise-list.css',
})
export class ExerciseList {
  exercieses = input<string[]>([])
  removeExersises = output<string>()

  onRemoveEvent(event: string) {
    this.removeExersises.emit(event)
  }
}
