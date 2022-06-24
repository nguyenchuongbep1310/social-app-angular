import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { EditprofileComponent } from '../editprofile/editprofile.component';
import { ImageService } from 'src/_services/image.service';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'wall',
  templateUrl: './wall.component.html',
  styleUrls: ['./wall.component.css'],
})
export class WallComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    private dialog: MatDialog,
    public imageService: ImageService
  ) {}

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
    gender: 'Male',
    avatar: null,
    email: null,
    phone: null,
    coverPhoto: null,
  };

  get tokenInfo(): {
    name: string;
    family_name: string;
    email: string;
    nameid: string;
    birthdate: string;
    Phone: string;
  } {
    const token = localStorage.getItem('token');
    if (token) {
      var decoded: {
        name: string;
        family_name: string;
        email: string;
        nameid: string;
        birthdate: string;
        Phone: string;
      } = jwt_decode(token);
      return decoded;
    }
    return null;
  }

  public username = '';

  ngOnInit(): void {
    var tokenInfo = this.tokenInfo;
    this.username = tokenInfo.nameid;

    this.imageService.getProfileInfo(this.username).subscribe((response) => {
      (this.profile.firstName = response.firstName),
        (this.profile.lastName = response.lastName),
        (this.profile.email = response.email),
        (this.profile.gender = response.gender),
        (this.profile.phone = response.phone),
        (this.profile.dateOfBirth = response.dateOfBirth),
        (this.profile.avatar =
          'https://localhost:44371/images/' + response.avatar),
        (this.profile.coverPhoto =
          'https://localhost:44371/images/' + response.coverPhoto);
    });
  }

  editProfile() {
    this.dialog.open(EditprofileComponent);
  }
}
