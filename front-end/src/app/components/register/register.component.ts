import { ThisReceiver } from '@angular/compiler';
import { Component, ElementRef, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(private elRef: ElementRef) {}

  ngOnInit(): void {}

  value: {
    firstNameValue: any;
    lastNameValue: any;
    usernameValue: any;
    passwordValue: any;
    confirmPasswordValue: any;
    birthdayValue: any;
    profilePictureValue: any;
    emailValue: any;
    phoneValue: any;
  } = {
    firstNameValue: null,
    lastNameValue: null,
    usernameValue: null,
    passwordValue: null,
    confirmPasswordValue: null,
    birthdayValue: null,
    profilePictureValue: null,
    emailValue: null,
    phoneValue: null,
  };

  getInput(event: Event, value: any, str: string) {
    value[str] = (event.target as HTMLInputElement).value;
    console.log(this.value.usernameValue);
  }
  blur(value: any, str: string) {
    if (value[str] === null) value[str] = '';
  }
}
