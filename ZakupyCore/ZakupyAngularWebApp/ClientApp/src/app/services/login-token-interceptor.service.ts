import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../authentication.service';

@Injectable({ providedIn: 'root' })
export class LoginTokenInterceptorService implements HttpInterceptor {

  constructor(
    private authenticationService: AuthenticationService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token: string;

    token = this.authenticationService.userToken;

    let request1 = request.clone({
      setHeaders: {
        AkAuthorizaation: 'ak001',
        ak_user_token: token
        //Authorization: `Bearer ${currentUser.token}`
      }
    });

    return next.handle(request1);
  }
}
