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
  ) {
    this.accountService.getProfile(this.profile);
  }

  ngOnInit(): void {
    
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
    firstName: null,
    lastName: null,
    username: null,
    dateOfBirth: null,
    gender: null,
    avatar: '',
    email: null,
    phone: null,
    coverPhoto: '',
  };

  editProfile() {
    this.dialog.open(EditprofileComponent);
  }
}
