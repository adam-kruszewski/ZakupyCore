import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AuthenticationService, User } from '../authentication.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      nazwa: ['', Validators.required],
      haslo: ['', [Validators.required]]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit(form) {
    let user: User | null;
    user = this.authenticationService.login(form.nazwa, form.haslo);

    if (user != null) {
      window.alert('Zalogowano:' + user.nazwa);
      this.router.navigate([this.returnUrl], { replaceUrl: true });
    }
    else
      window.alert('Błąd logowania');
  }
}
