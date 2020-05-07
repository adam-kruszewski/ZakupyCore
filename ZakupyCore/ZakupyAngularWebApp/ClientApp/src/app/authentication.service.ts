import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  user: User | null;
  constructor() { }

  public get currentUserValue(): User | null {
    this.user = JSON.parse(localStorage.getItem('currentUser'));
    return this.user;
  }

  login(username: string, password: string): User | null {
    let u: User;
    u = new User();
    u.id = 12;
    u.nazwa = username;
    u.email = "a.a@b.c.pl";

    localStorage.setItem('currentUser', JSON.stringify(u));

    return u;
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.user = null;
  }
}

export class User {
  id: number;
  nazwa: string;
  email: string;
}
