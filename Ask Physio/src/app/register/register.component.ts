import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DoctorModel } from '../models/DoctorModel';
import { PatientService } from '../services/patient.service';
import { DoctorService } from '../services/doctor.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  patientRegistrationForm: FormGroup;
  doctorRegistrationForm: FormGroup;
  patientModel= new PatientModel();
  doctorModel= new DoctorModel();
  isPatientFormSubmitted = false;
  constructor(private router: Router, private fb: FormBuilder,
  private patientService:PatientService,private doctorService:DoctorService) { }

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
      gender: ["", [Validators.required]]
    });
    this.doctorRegistrationForm = this.fb.group({
      firstName: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
      password: ["", [Validators.required]],
      confirmPassword: ["", [Validators.required]],
      email: ["", [Validators.required]],
      phoneNo: ["", [Validators.required]],
      address: ["", [Validators.required]],
      gender: ["", [Validators.required]],
      registrationNo: ["", [Validators.required]]
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
    },error=>{}
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
    },error=>{}
    )
  }
  saveDoctor() {
    this.isPatientFormSubmitted = true;
    if(!this.patientRegistrationForm.valid)
    {
      return;
    }
    this.doctorModel = Object.assign({},this.doctorModel,this.patientRegistrationForm.value);
    this.doctorService.create(this.doctorModel).subscribe(res=>{
    },error=>{}
    )
  }
  updateDoctor() {
    this.isPatientFormSubmitted = true;
    if(!this.patientRegistrationForm.valid)
    {
      return;
    }
    this.doctorModel = Object.assign({},this.doctorModel,this.patientRegistrationForm.value);
    this.doctorService.update(this.doctorModel).subscribe(res=>{
    },error=>{}
    )
  }
  goToProfile() {
    this.router.navigate(["/askphysio/dashboard"]);
  }


}
