import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
 baseUrl:string = "https://localhost:44336/api/physio/v1/";
  constructor() { }

  getBaseUrl()
  {
   return this.baseUrl;
  }

}
