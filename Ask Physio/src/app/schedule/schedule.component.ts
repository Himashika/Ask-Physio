import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {

  constructor(private fb :FormBuilder,) { }
  scheduleForm : FormGroup;
  ngOnInit() {
    this.initiateForm();
  }

  initiateForm()
  {
  this.scheduleForm = this.fb.group({
    fromDate :["",[Validators.required]],
    toDate:["",[Validators.required]],
    fromTime:["",[Validators.required]],
    toTime:["",[Validators.required]],
    address:["",[Validators.required]],
    city:["",[Validators.required]],
    postalCode:["",[Validators.required]],
    description:["",[]],
  })
  }
}
