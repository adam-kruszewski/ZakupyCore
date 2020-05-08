import { Component } from '@angular/core';
import { AuthenticationService, User } from '../authentication.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  private user: Observable<User>;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router) {
    this.user = authenticationService.currentUser;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onWyloguj() {
    this.authenticationService.logout();

    this.router.navigate(['/'], { replaceUrl: true });
  }
}
