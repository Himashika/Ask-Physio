import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { UserLogin } from '../models/UserLogin';
import { Router } from '@angular/router';
import { fail } from 'assert';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router,private fb : FormBuilder,private logingService:LoginService) { }
  patientForm :FormGroup;
  doctorForm : FormGroup;
  userLogin = new UserLogin();
  token:any;
  showError=false ;
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
    return;
  }
  this.userLogin = Object.assign({},this.userLogin,this.patientForm.value);
  this.userLogin.UserRole = "Patient";
  this.logingService.create(this.userLogin).subscribe(res=>{
    this.token = res;
    if(this.token.value!=null)
    this.showError=false ;
     localStorage.setItem('Token_id',this.token.value);
     localStorage.setItem('User_info',this.token.value)
     this.goToProfilePatient();
  },error=>{
    debugger;
    this.showError=true ;
  }
  )
}
doctorLogin()
{
  this.isDoctorFormSubmitted = true;
  if(!this.doctorForm.valid)
  {
    return;
  }
  this.userLogin = Object.assign({},this.userLogin,this.doctorForm.value);
  this.userLogin.UserRole = "Consultant";
  this.logingService.create(this.userLogin).subscribe(res=>{
    this.token = res;
    if(this.token.value!=null)
    this.showError=false ;
     localStorage.setItem('Token_id',this.token.value);
     localStorage.setItem('User_info',this.token.value)
     this.goToProfileDoctor();
  },error=>{
    this.showError=true ;
  }
  )
}

goToProfilePatient()
{
  this.router.navigate(["/askphysio/dashboard"]); 
}
goToProfileDoctor()
{
  this.router.navigate(["/askphysio/dashboard-doctor"]); 
}
}
