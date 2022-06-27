import { Component, ElementRef, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/_services/account.service';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';

@Component({
  selector: 'editprofile',
  templateUrl: './editprofile.component.html',
  styleUrls: ['./editprofile.component.css'],
})
export class EditprofileComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    private _router: Router,
    public dialog: MatDialog
  ) {
    this.accountService.getProfile(this.value);
  }

  ngOnInit(): void {}

  public value: {
    firstName: string;
    lastName: string;
    username: string;
    dateOfBirth: any;
    gender: string;
    avatar: any;
    coverPhoto: any;
    email: string;
    phone: string;
  } = {
    firstName: null,
    lastName: null,
    username: null,
    dateOfBirth: null,
    gender: null,
    avatar: '',
    coverPhoto: '',
    email: null,
    phone: null,
  };

  public formatDate() {
    var d = this.value.dateOfBirth.split('/');

    console.log(d.reverse().join('-'));
    console.log('--------------');

    return d.reverse().join('-');
  }

  public hitCancel: boolean = false;

  public getInput(event: Event, value: any, str: string) {
    value[str] = (event.target as HTMLInputElement).value;
  }

  public blur(value: any, str: string) {
    if (value[str] === null) value[str] = '';
  }

  public navigateToLogin() {
    this._router.navigateByUrl('/login');
  }

  onNoClick(): void {
    this.dialog.closeAll();
  }

  onFileChanged(event: any, s: string) {
    this.value[s] = event.target.files[0];
  }

  onSave() {
    this.onEditProfile();
  }

  public onEditProfile(): void {
    let myDate = new Date(this.value.dateOfBirth);
    let date = myDate.toLocaleDateString('en-AU');

    this.value.dateOfBirth = date;

    this.accountService.editProfile(this.value).subscribe((response) => {
      location.reload();
    });
  }
}
