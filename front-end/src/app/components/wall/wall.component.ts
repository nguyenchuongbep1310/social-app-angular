import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { EditprofileComponent } from '../editprofile/editprofile.component';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'wall',
  templateUrl: './wall.component.html',
  styleUrls: ['./wall.component.css'],
})
export class WallComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.accountService.getAvatarAndCover(this.profile);
  }

  public profile: {
    firstName: any;
    lastName: any;
    username: any;
    dateOfBirth: any;
    gender: any;
    avatar: any;
    email: any;
    phone: any;
    coverPhoto: any;
  } = {
    firstName: this.accountService.name,
    lastName: this.accountService.familyName,
    username: this.accountService.userName,
    dateOfBirth: this.accountService.birthDay,
    gender: this.accountService.gender,
    avatar: '',
    email: this.accountService.email,
    phone: this.accountService.phone,
    coverPhoto: '',
  };

  editProfile() {
    this.dialog.open(EditprofileComponent);
  }
}
