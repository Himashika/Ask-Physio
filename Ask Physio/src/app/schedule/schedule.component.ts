import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ScheduleModel } from '../models/scheduleModel';
import { ScheduleService } from '../services/schedule.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {
  isScheduleFormSubmitted = false;
  id: number;
  scheduleForm : FormGroup;
  scheduleModel = new ScheduleModel();
  scheduleModels = [];
  
  constructor(private fb :FormBuilder,private scheduleService : ScheduleService) { }

  ngOnInit() {
    this.initiateForm();
  }

  initiateForm()
  {
  this.scheduleForm = this.fb.group({
    date :["",[Validators.required]],
    fromTime:["",[Validators.required]],
    toTime:["",[Validators.required]],
    address:["",[Validators.required]],
    city:["",[Validators.required]],
    postalCode:["",[Validators.required]],
    description:["",[]],
  })
  }

  saveSchedule() {
    this.isScheduleFormSubmitted = true;
    if(!this.scheduleForm.valid)
    {
      return;
    }
    this.scheduleModel = Object.assign({},this.scheduleModel,this.scheduleForm.value);
    this.scheduleService.create(this.scheduleModel).subscribe(res=>{
    },error=>{}
    )
  }

  deleteSchedule() {
    this.isScheduleFormSubmitted = true;
    this.scheduleService.delete(this.id).subscribe(res=>{
    },error=>{}
    )
  }

  getSchedules() {   
    this.scheduleService.getAll().subscribe(res=>{
      this.scheduleModels  = res;
    },error=>{}
    )
  }
}
