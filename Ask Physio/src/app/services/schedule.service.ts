import { Injectable } from '@angular/core';
import { AppConfigService } from '../core/app-config.service';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService extends BaseService {
  constructor(protected http:HttpClient,private appConfig:AppConfigService) {
    super(http,appConfig.getBaseUrl()+'/Schedules');
  }
 
}
