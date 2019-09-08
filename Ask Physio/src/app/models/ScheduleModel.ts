import { Time } from '@angular/common';

export class ScheduleModel {
    Id : number
    DoctorId  : number;
    Date : Date;
    City : string;
    PostalCode : number;
    Description : string;
    FromTime : Time;
    ToTime : Time;
    Address : string;

    
}