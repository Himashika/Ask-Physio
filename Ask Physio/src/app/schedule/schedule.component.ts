import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
// export class DemoDatepickerBasicComponent {}
export class ScheduleComponent implements OnInit {

  // ismeridian: boolean = true;
 
  // fromtime: Date = new Date();
  // totime: Date = new Date();
  constructor() { }

  ngOnInit() {
  }

  toggleMode(): void {
    // this.ismeridian = !this.ismeridian;
  }

}
