import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor() {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User | null {
    return this.currentUserSubject.value;
  }

  login(username: string, password: string): User | null {
    let u: User;
    u = new User();
    u.id = 12;
    u.nazwa = username;
    u.email = "a.a@b.c.pl";

    localStorage.setItem('currentUser', JSON.stringify(u));
    this.currentUserSubject.next(u);

    return u;
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}

export class User {
  id: number;
  nazwa: string;
  email: string;
}
