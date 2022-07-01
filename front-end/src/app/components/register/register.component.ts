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
    this.errors = {};
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

    this.accountService.register(this.value).subscribe(
      (response) => {
        if (response.success == true) {
          alert('Your account has been created successfully.');
          this.navigateToLogin();
        }
      },
      (error) => {
        const errors = error.error.errors;

        if (errors.FirstName) this.errors.errorFirstName = errors.FirstName[0];
        if (errors.LastName) this.errors.errorLastName = errors.LastName[0];
        if (errors.Username) this.errors.errorUsername = errors.Username[0];
        if (errors.Password) this.errors.errorPassword = errors.Password[0];
        if (errors.ConfirmPassword)
          this.errors.errorConfirmPassword = errors.ConfirmPassword[0];
        if (errors.Email) this.errors.errorEmail = errors.Email[0];
        if (errors.Phone) this.errors.errorPhoneNumber = errors.Phone[0];
        if (errors.DateOfBirth)
          this.errors.errorBirthday = errors.DateOfBirth[0];
      }
    );
  }

  public errors: any = {};
}
