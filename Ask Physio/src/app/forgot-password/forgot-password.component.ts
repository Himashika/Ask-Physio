import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLogin } from '../models/UserLogin';


@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {

  constructor(private router: Router,private fb : FormBuilder,private vRef: ViewContainerRef) 
    // logingService:LoginService,
    
    { 
    //  this.toastr.setRootViewContainerRef(vRef);
    }
  resetForm:FormGroup;
  isResetFormSubmitted= false;
  userLogin = new UserLogin();
  token:any;
  showError=false ;
  ngOnInit() {
    this.formInitialized()
  }
 
  formInitialized(){
    this.resetForm =  this.fb.group({
      userName:["",[Validators.required]],
      password:["",[Validators.required]],
      resetpassword:["",[Validators.required]]
    })
}
resetPassword()
{
  this.isResetFormSubmitted = true;
  if(!this.resetForm.valid)
  {
    return;
  }
  this.userLogin = Object.assign({},this.userLogin,this.resetForm.value);
  this.userLogin.UserRole = "Reset";
  // this.logingService.create(this.userLogin).subscribe(res=>{
    // this.token = res;
    if(this.token.value!=null)
    this.showError=false ;
     localStorage.setItem('Token_id',this.token.value);
     localStorage.setItem('User_info',this.token.value)
  //    this.goToProfileReset();
  // },error=>{
  //   debugger;
  //   this.showError=true ;
  // }
  // )
}
}