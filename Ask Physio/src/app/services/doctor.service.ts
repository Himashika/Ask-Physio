import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { AppConfigService } from '../core/app-config.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DoctorService extends BaseService {
constructor(protected http:HttpClient,private appConfig:AppConfigService,private baseService:BaseService) {
    super(http,appConfig.getBaseUrl()+'/loging');
  }
}
