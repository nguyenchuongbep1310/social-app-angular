import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/_services/account.service';


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

  login()
  {
    this.accountService.login(this.model).subscribe(response =>{
      console.log(response);
      this.loggedIn = true;
    }, error =>{
      console.log(error);
    })
  }

  logout(){
    this.loggedIn = false;
  }
  navigateToRegister() {
    this._router.navigateByUrl('/register');
  }

  navigateToDashBoard(){
    this._router.navigateByUrl('dashboard');
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
