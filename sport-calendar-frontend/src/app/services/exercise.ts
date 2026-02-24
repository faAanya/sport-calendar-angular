import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Exercise {
  private storageKey = 'exercises';
  exercises: {[key: string]: string[]} = {}
  private readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
    this.loadEvents();
  }
  loadEvents() {
   const storedEvents = localStorage.getItem(this.storageKey);
        if (storedEvents) {
            this.exercises = JSON.parse(storedEvents);
        }
  }
  getExercises(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/calendar`);
  }
  getExercisesByDate(dateString: string): Observable<any[]> {
  const params = new HttpParams().set('date', dateString);
  return this.http.get<any[]>(`${this.baseUrl}/calendar`, { params });
}

}
