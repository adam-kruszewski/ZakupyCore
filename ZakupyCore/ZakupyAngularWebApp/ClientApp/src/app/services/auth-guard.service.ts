import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot  } from '@angular/router';
import { AuthenticationService, User } from '../authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(
    private authenticationService: AuthenticationService,
    public router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let user: User | null;
    user = this.authenticationService.currentUserValue;
    if (user == null) {
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
      return false;
    }
    return true;
  }
}
