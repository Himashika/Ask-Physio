import {HttpInterceptor,HttpClient } from '@angular/common/http';
import { HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { HttpHandler } from '@angular/common/http';
import { HttpSentEvent } from '@angular/common/http';
import { HttpHeaderResponse } from '@angular/common/http';
import { HttpProgressEvent } from '@angular/common/http';
import { HttpResponse } from '@angular/common/http';
import { HttpUserEvent } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
export class TokenInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpSentEvent | HttpHeaderResponse | HttpProgressEvent | HttpResponse<any> | HttpUserEvent<any>> {
   
            // Get the auth token from the service.
            const authToken = localStorage.getItem("Token_id")
    
            // Clone the request and replace the original headers with
            // cloned headers, updated with the authorization.
    
            const headers = new HttpHeaders({
                'Authorization': 'bearer ' + authToken         
            });
    
            const cloneReq = req.clone({ headers });
    
            // send cloned request with header to the next handler.
            return next.handle(cloneReq);
        

    }
}