import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService, User } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm;

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      nazwa: ['', Validators.required],
      haslo: ['', [Validators.required]]
    });
  }

  onSubmit(form) {
    let user: User | null;
    user = this.authenticationService.login(form.nazwa, form.haslo);

    if (user != null)
      window.alert('Zalogowano:' + user.nazwa);
    else
      window.alert('Błąd logowania');
  }
}
