import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfigService } from '../core/app-config.service';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PatientService extends BaseService {
  constructor(protected http:HttpClient,private appConfig:AppConfigService) {
    super(http,appConfig.getBaseUrl()+'/patients');
  }
}
