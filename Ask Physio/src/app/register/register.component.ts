import { Component, OnInit } from '@angular/core';
import { Router} from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  patientRegistrationForm :FormGroup;
  doctorRegistrationForm :FormGroup;

  isPatientFormSubmitted = false;
  constructor(private router : Router , private fb: FormBuilder) { }

  ngOnInit() {
    this.formInitialized();
  }
  formInitialized(){
    this.patientRegistrationForm =  this.fb.group({
      userName:["",[Validators.required]],
      password:["",[Validators.required]]
    });
    this.doctorRegistrationForm =  this.fb.group({
      userName:["",[Validators.required]],
      password:["",[Validators.required]]
    });
  }

  
  goToProfile()
  {
    this.router.navigate(["/askphysio/dashboard"]);
  }


}
