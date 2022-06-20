import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/_services/account.service';
import * as jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  model: any = {};
  loggedIn: boolean;

  constructor(
    private _router: Router,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {}

  errFromAPI: string = '';

  value: { username: any; password: any } = {
    username: null,
    password: null,
  };

  // login()
  // {
  //   this.accountService.login(this.model).subscribe(response =>{
  //     console.log(response);
  //     this.loggedIn = true;
  //   }, error =>{
  //     console.log(error);
  //   })
  // }
  public onSubmitLogin(): void {
    this.accountService.login(this.value).subscribe(
      (response) => {
        if (response) {
          localStorage.setItem('token', response.token);
          this.navigateToDashBoard();
        }
      },
      (error) => {
        this.errFromAPI = 'Your username or password is incorrect';
      }
    );
  }
  logout() {
    this.loggedIn = false;
  }
  navigateToRegister() {
    this._router.navigateByUrl('/register');
  }

  navigateToDashBoard() {
    this._router.navigateByUrl('/home');
  }

  getInput(event: Event, value: any, str: string) {
    value[str] = (event.target as HTMLInputElement).value;
    this.errFromAPI = '';
  }

  blur(value: any, str: string) {
    if (value[str] === null) value[str] = '';
  }
}
