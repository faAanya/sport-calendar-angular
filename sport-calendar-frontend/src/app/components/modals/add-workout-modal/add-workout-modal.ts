import { Component, EventEmitter, Input, OnInit, Output, inject, input, output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Exercise } from '../../../services/exercise';

@Component({
  selector: 'app-add-workout-modal',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe],
  templateUrl: './add-workout-modal.html',
  styleUrls: ['./add-workout-modal.css']
})
export class AddWorkoutModal implements OnInit {
  selectedDate = input.required<Date>();
  close = output<void>();
  save = output<any>();

  private fb = inject(FormBuilder);
  
  private exerciseService = inject(Exercise);

  workoutForm!: FormGroup;
  
  activities: any[] = []; 
  metrics: any[] = [];
  units: any[] = [];

  ngOnInit() {
    this.initForm();
    this.fetchDashboardData();
    this.fetchMetrics(); 
  }

  initForm() {
    this.workoutForm = this.fb.group({
      activityId: ['', Validators.required],
      unitId: ['', Validators.required],
      targetValue: ['', [Validators.required, Validators.min(0)]]
    });
  }

  fetchDashboardData() {
    this.exerciseService.getDashboardDetails().subscribe({
      next: (data) => {
        this.activities = data.activityTypes;
        this.units = data.units;
      },
      error: (err) => {
        console.error('Error fetching dashboard data:', err);
      }
    });
  }

  fetchMetrics() {
    this.metrics = [
      { id: 1, name: 'Distance' },
      { id: 2, name: 'Duration' },
      { id: 3, name: 'Repetitions' }
    ];
  }

  onSubmit() {
    if (this.workoutForm.valid) {
      this.save.emit({ date: this.selectedDate(), ...this.workoutForm.value });
    }
  }
}