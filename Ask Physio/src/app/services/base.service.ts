import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
 // 

  constructor(protected http: HttpClient, protected actionUrl: string) {
  }

  getAllByFilter(name): Observable<any> {
    if(name == "")
    {
      name = null;
    }
    return this.http.get(`${this.actionUrl}/${name}`)
      .map((response) => response)
      .catch(this.errorHandler);
  }
  // getAllByFilter(search: string): Observable<any> {

  //   return this.http.get(`${this.actionUrl+'/appoiments'}/${name}`)
  //     .map((response) => response)
  //     .catch(this.errorHandler);
  // }

  getAll(): Observable<any> {
    return this.http.get(`${this.actionUrl}`)
      .map((response) => response)
      .catch(this.errorHandler);
  }
  getById(id: number): Observable<any> {
    return this.http.get(`${this.actionUrl}/${id}`).map(res => res).catch(this.errorHandler);
  }
  
  create(entity: any) {

    return this.http.post(this.actionUrl, entity).map((res) => res).catch(this.errorHandler);
  }
  
  sendMail(entity: any) {
    debugger;
    return this.http.post('https://localhost:44336/api/physio/v1/Doctors/sendRequest', entity).map((res) => res).catch(this.errorHandler);
  }

  createFormData(files, entity: any){
    let formData: FormData = new FormData();
    formData.append('imageUpload', files);
    formData.append('entityData', JSON.stringify(entity));
  
    return this.http.post(this.actionUrl, formData, this.httpOptionsFormDataType).map(res => res).catch(this.errorHandler);
  }
  
  update(entity: any) {
    return this.http.put(this.actionUrl, entity, this.httpOptions).map(res => res).catch(this.errorHandler);
  }
  
  updateFormData(files, entity: any){
    let formData: FormData = new FormData();
    formData.append('imageUpload', files);
    formData.append('entityData', JSON.stringify(entity));
  
    return this.http.put(this.actionUrl, formData, this.httpOptionsFormDataType).map(res => res).catch(this.errorHandler);
  }
  
  delete(id: number) {
    return this.http.delete(`${this.actionUrl}/${id}`, this.httpOptions).map((response) => response).catch(this.errorHandler);
  }
  
  protected extractData(res: Response) {
    return res.json
  }
  private extractDataRequests(res: Response) {
  
    return JSON.parse(res['_body']).value;
  }
  
  protected errorHandler(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
      return Observable.throw(error);
    } else {
      console.error(error.error.result ? error.error.result : error.toString());
      return Observable.throw(error);
    }    
  }
  
  protected httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };
  
  protected httpOptionsFormType = {
    headers: new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
    })
  };
  
  protected httpOptionsFormDataType = {
    headers: new HttpHeaders({
      'enctype': 'multipart/form-data'
    })
  };
}
