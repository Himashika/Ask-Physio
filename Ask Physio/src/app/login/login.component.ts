import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private fb : FormBuilder,private logingService:LoginService) { }
  patientForm :FormGroup;
  doctorForm : FormGroup;
  userLogin = new UserLogin();
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
    userName:["",[Validators.required]],
    password:["",[Validators.required]]
  })
}
patientLogin()
{
  this.isPatientFormSubmitted = true;
  if(!this.patientForm.valid)
  {
  this.userLogin.UserName = "sathya";
  this.userLogin.Password = "123";
  this.logingService.create(this.userLogin)
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
