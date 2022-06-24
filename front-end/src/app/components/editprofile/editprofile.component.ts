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
  ) {}

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
    firstName: this.accountService.name,
    lastName: this.accountService.familyName,
    username: this.accountService.userName,
    dateOfBirth: this.accountService.birthDay,
    gender: this.accountService.gender,
    avatar: null,
    coverPhoto: null,
    email: this.accountService.email,
    phone: this.accountService.phone,
  };
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
    console.log(this.value);
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
