import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User | null {
    return this.currentUserSubject.value;
  }

  public get userToken(): string {
    return localStorage.getItem('userToken');
  }

  login(username: string, password: string): Observable<User> {
    let request = new AuthenticationRequest();
    request.UsernameOrEmail = username;
    request.Password = password;

    let user: Observable<User>;
    user =
      this.http.post<AuthenticationResult>('/api/Authentication', request)
        .pipe<User>(
          map((data: AuthenticationResult): User =>
            this.getUser(data)));

    return user;
  }

  private getUser(authResult: AuthenticationResult): User {
    if (authResult == null || !authResult.success) {
      this.logout();
      return null;
    }

    let user: User;
    user = new User();
    user.nazwa = authResult.identity.name;
    user.email = authResult.identity.email;

    localStorage.setItem('currentUser', JSON.stringify(user));
    localStorage.setItem('userToken', authResult.token);

    this.currentUserSubject.next(user);

    return user;
  }

  logout() {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('userToken');
    this.currentUserSubject.next(null);
  }
}

export class User {
  id: number;
  nazwa: string;
  email: string;
}

class AuthenticationRequest {
  UsernameOrEmail: string
  Password: string
}

class AuthenticationResult {
  success: boolean;

  identity: UserIdentity;

  token: string;
}

class UserIdentity {
  name: string;

  email: string;
}
