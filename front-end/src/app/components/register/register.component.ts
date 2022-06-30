import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(
    private accountService: AccountService,
    private _router: Router
  ) {}

  ngOnInit(): void {}

  public value: {
    firstName: any;
    lastName: any;
    username: any;
    password: any;
    confirmPassword: any;
    dateOfBirth: any;
    gender: any;
    avatar: any[];
    email: any;
    phone: any;
  } = {
    firstName: null,
    lastName: null,
    username: null,
    password: null,
    confirmPassword: null,
    dateOfBirth: null,
    gender: 'Male',
    avatar: null,
    email: null,
    phone: '',
  };

  public getInput(event: Event, value: any, str: string) {
    value[str] = (event.target as HTMLInputElement).value;
  }

  public blur(value: any, str: string) {
    if (value[str] === null) value[str] = '';
  }

  public onFileChanged(event: any) {
    this.value.avatar = event.target.files[0];
  }

  public navigateToLogin() {
    this._router.navigateByUrl('/login');
  }

  public formatDate() {
    if (this.value.dateOfBirth) {
      var d = this.value.dateOfBirth.split('/');
      const dateFormat = d.reverse().join('-');

      return dateFormat;
    }
    return 'YYYY/MM/DD';
  }

  public onSubmitRegister(): void {
    let myDate = new Date(this.value.dateOfBirth);
    let date = myDate.toLocaleDateString('en-AU');

    this.value.dateOfBirth = date;

    this.accountService.register(this.value).subscribe((response) => {
      if (response.success == true) {
        alert('Your account has been created successfully.');
        this.navigateToLogin();
      }
    });
  }
}
