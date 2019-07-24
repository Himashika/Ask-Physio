import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { LoginService } from './services/login.service';
import { AppConfigService } from './core/app-config.service';
import { DoctorService } from './services/doctor.service';
import { PatientService } from './services/patient.service';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { ScheduleComponent } from './schedule/schedule.component';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    TimepickerModule.forRoot()
   
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    RegisterComponent,
    LoginComponent
  ],
  providers: [LoginService,AppConfigService,PatientService,DoctorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
