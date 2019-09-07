import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators,Validator } from '@angular/forms';
import { DoctorModel } from '../models/DoctorModel';
import { PatientService } from '../services/patient.service';
import { DoctorService } from '../services/doctor.service';
import { PatientModel } from '../models/PatientModel';
import { PasswordValidation } from '../core/PasswordValidation';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  patientRegistrationForm: FormGroup;
  doctorRegistrationForm: FormGroup;

  doctorModel= new DoctorModel();
  patientModel= new PatientModel();

  isPatientFormSubmitted = false;
  isDoctorFormSubmitted = false;
  constructor(private router: Router, private fb: FormBuilder,private doctorService:DoctorService,private patientService: PatientService,
    vRef: ViewContainerRef) {
      //this.toastr.setRootViewContainerRef(vRef);
     }

  ngOnInit() {
    this.formInitialized();
  }
  formInitialized() {
    this.patientRegistrationForm = this.fb.group({
      firstName: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
      password: ["", [Validators.required]],
      confirmPassword: ["", [Validators.required]],
      email: ["", [Validators.required]],
      phoneNo: ["", [Validators.required]],
      address: ["", [Validators.required]],
      gender: [0, [Validators.required]]
    });
    this.doctorRegistrationForm = this.fb.group({
      firstName: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
      password: ["", [Validators.required]],
      confirmPassword: ["", [Validators.required]],
      email: ["", [Validators.required]],
      phoneNo: [0, [Validators.required]],
      gender: [0, [Validators.required]],
      registrationNo: ["", [Validators.required]]
    },
    {
      validator : PasswordValidation.MatchPassword
    });
  }
  savePatient() {
    this.isPatientFormSubmitted = true;
    if(!this.patientRegistrationForm.valid)
    {
      return;
    }
    this.patientModel = Object.assign({},this.patientModel,this.patientRegistrationForm.value);
    this.patientService.create(this.patientModel).subscribe(res=>{
    //  this.toastr.success("Saved SuccesFully");
    },error=>{
     // this.toastr.success("Error Saving");
    }
    )
  }
  updatePatient() {
    this.isPatientFormSubmitted = true;
    if(!this.patientRegistrationForm.valid)
    {
      return;
    }
    this.patientModel = Object.assign({},this.patientModel,this.patientRegistrationForm.value);
    this.patientService.update(this.patientModel).subscribe(res=>{
     // this.toastr.success("Updated SuccesFully");
    },error=>{
     // this.toastr.success("Error Updating");
    }
    )
  }
  saveDoctor() {
    debugger;
    this.isDoctorFormSubmitted = true;
    if(!this.doctorRegistrationForm.valid)
    {
      return;
    }
    this.doctorModel = Object.assign({},this.doctorModel,this.doctorRegistrationForm.value);
    this.doctorService.create(this.doctorModel).subscribe(res=>{
    //  this.toastr.success("Saved SuccesFully");
    },error=>{
     // this.toastr.success("Error Saving");
    }
    )
  }
  updateDoctor() {
    this.isDoctorFormSubmitted = true;
    if(!this.doctorRegistrationForm.valid)
    {
      return;
    }
    this.doctorModel = Object.assign({},this.doctorModel,this.doctorRegistrationForm.value);
    this.doctorService.update(this.doctorModel).subscribe(res=>{
      //this.toastr.success("Updated SuccesFully");
    },error=>{
      // this.toastr.success("Error Updating");
    }
    )
  }
  goToProfile() {
    this.router.navigate(["/askphysio/dashboard"]);
  }
  goToProfileDoctor()
{
  this.router.navigate(["/askphysio/dashboard-doctor"]); 
}

}
