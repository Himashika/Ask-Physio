import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  patientRegistrationForm: FormGroup;
  doctorRegistrationForm: FormGroup;

  isPatientFormSubmitted = false;
  constructor(private router: Router, private fb: FormBuilder) { }

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

  }
  updatePatient() {

  }
  saveDoctor() {

  }
  updateDoctor() {

  }
  goToProfile() {
    this.router.navigate(["/askphysio/dashboard"]);
  }


}
