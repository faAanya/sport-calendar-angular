import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../environment/environment';
import { Observable } from 'rxjs';
import { WorkoutModel } from '../models/workout.model';

@Injectable({
  providedIn: 'root',
})
export class Exercise {
  exercises: {[key: string]: string[]} = {}
  private readonly baseUrl = environment.apiUrl;
  http = inject(HttpClient);
  
  constructor() {}

  getDashboardDetails(): Observable<{units: any[], activityTypes: any[]}> {
    return this.http.get<{units: any[], activityTypes: any[]}>(`${this.baseUrl}/calendar/dashboard`);
  }

  getExercisesByDate(dateString: string): Observable<any[]> {
    const params = new HttpParams().set('date', dateString);
    return this.http.get<any[]>(`${this.baseUrl}/workout/day`, { params });
  }

  createWorkout(newWorkout: WorkoutModel): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/workout`, newWorkout);
  }

  updateWorkout(id: number, updatedWorkout: any): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/workout/${id}`, updatedWorkout);
  }
  
  deleteWorkout(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/workout/${id}`);
  }
}
