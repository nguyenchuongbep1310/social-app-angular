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

  value: { usernameValue: any; passwordValue: any } = {
    usernameValue: null,
    passwordValue: null,
  };

  getInput(event: Event, value: any, str: string) {
    value[str] = (event.target as HTMLInputElement).value;
    console.log(this.value.usernameValue);
  }
  blur(value: any, str: string) {
    if (value[str] === null) value[str] = '';
  }
}
