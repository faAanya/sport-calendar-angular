import { Component } from '@angular/core';
import { MonthView } from '../month-view/month-view';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-calendar',
  imports: [MonthView, DatePipe],
  templateUrl: './calendar.html',
  styleUrl: './calendar.css',
})
export class Calendar {
  currentDate = new Date()

  changeMonth(offset: number) {
  this.currentDate = new Date(
    this.currentDate.getFullYear(),
    this.currentDate.getMonth() + offset,
    1
  );
}
}
