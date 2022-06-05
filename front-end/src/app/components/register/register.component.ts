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

  firstNameValue: any = null;
  getFirstNameInput(event: Event) {
    this.firstNameValue = (event.target as HTMLInputElement).value;
  }
  firstNameBlur() {
    if (this.firstNameValue === null) this.firstNameValue = '';
  }

  lastNameValue: any = null;
  getLastNameInput(event: Event) {
    this.lastNameValue = (event.target as HTMLInputElement).value;
  }
  lastNameBlur() {
    if (this.lastNameValue === null) this.lastNameValue = '';
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

  confirmPasswordValue: any = null;
  getConfirmPasswordInput(event: Event) {
    this.confirmPasswordValue = (event.target as HTMLInputElement).value;
  }
  confirmPasswordBlur() {
    if (this.confirmPasswordValue === null) this.confirmPasswordValue = '';
  }

  birthdayValue: any = null;
  getBirthdayInput(event: Event) {
    this.birthdayValue = (event.target as HTMLInputElement).value;
  }
  birthdayBlur() {
    if (this.birthdayValue === null) this.birthdayValue = '';
  }

  profilePictureValue: any = null;

  emailValue: any = null;
  getEmailInput(event: Event) {
    this.emailValue = (event.target as HTMLInputElement).value;
  }
  emailBlur() {
    if (this.emailValue === null) this.emailValue = '';
  }

  phoneValue: any = null;
}
