import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/_services/account.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  model: any = {}
  loggedIn : boolean;

  constructor(private _router: Router, private accountService: AccountService ) {}

  ngOnInit(): void {}

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

    this.accountService.login(this.value).subscribe(response => {

      console.log(response);
      if(response)
      {
        localStorage.setItem('token', response.token);
        this.navigateToDashBoard();
      }
    });
  }
  logout(){
    this.loggedIn = false;
  }
  navigateToRegister() {
    this._router.navigateByUrl('/register');
  }

  navigateToDashBoard(){
    this._router.navigateByUrl('/home');
  }

  value: { username: any; password: any } = {
    username: null,
    password: null,
  };

  getInput(event: Event, value: any, str: string) {
    value[str] = (event.target as HTMLInputElement).value;
    console.log(this.value.username);
  }
  blur(value: any, str: string) {
    if (value[str] === null) value[str] = '';
  }

  
}
