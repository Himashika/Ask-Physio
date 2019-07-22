import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private fb : FormBuilder) { }
  patientForm :FormGroup;
  doctorForm : FormGroup;
  isPatientFormSubmitted = false;
  isDoctorFormSubmitted = false;
  ngOnInit() {
    this.formInitialized()
  }
 
formInitialized(){
  this.patientForm =  this.fb.group({
    userName:["",[Validators.required]],
    password:["",[Validators.required]]
  });
  this.doctorForm = this.fb.group({
    xx:["",[Validators.required]],
    password:["",[Validators.required]]
  })
}
patientLogin()
{
  this.isPatientFormSubmitted = true;
  if(!this.patientForm.valid)
  {
    return;
  }

}
doctorLogin()
{
  this.isDoctorFormSubmitted = true;
  if(!this.doctorForm.valid)
  {
    return;
  }
}
}
