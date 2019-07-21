import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { AppConfigService } from '../core/app-config.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends BaseService {
  constructor(protected http:HttpClient,private appConfig:AppConfigService,private baseService:BaseService) {
    super(http,appConfig.getBaseUrl()+'Security/Authenticate');
    
  }
}
