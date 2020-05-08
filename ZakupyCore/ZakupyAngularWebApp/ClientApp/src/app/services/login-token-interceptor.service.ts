import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class LoginTokenInterceptorService implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add authorization header with jwt token if available
    //let currentUser = this.authenticationService.currentUserValue;
    //if (currentUser && currentUser.token) {
      let request1 = request.clone({
        setHeaders: {
          AkAuthorizaation: 'ak001'
          //Authorization: `Bearer ${currentUser.token}`
        }
      });
    request1.headers.append('ak_test', 'ak001');
    //}

    return next.handle(request1);
  }
}
