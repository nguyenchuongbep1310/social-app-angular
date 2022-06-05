import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private _router: Router) {}

  ngOnInit(): void {}

  navigateToRegister() {
    this._router.navigateByUrl('/register');
  }

  usernameValue: any = null;
  getUsernameInput(event: Event) {
    this.usernameValue = (event.target as HTMLInputElement).value;
  }
  usernameBlur() {
    if (this.usernameValue === null) this.usernameValue = '';
  }

  passwordValue: any = null;
  getPasswordInput(event: Event) {
    this.passwordValue = (event.target as HTMLInputElement).value;
  }
  passwordBlur() {
    if (this.passwordValue === null) this.passwordValue = '';
  }
}
