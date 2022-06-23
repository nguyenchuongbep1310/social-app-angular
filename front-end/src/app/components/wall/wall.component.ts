import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { EditprofileComponent } from '../editprofile/editprofile.component';
import { ImageService } from 'src/_services/image.service';

@Component({
  selector: 'wall',
  templateUrl: './wall.component.html',
  styleUrls: ['./wall.component.css']
})
export class WallComponent implements OnInit {

  constructor( public accountService: AccountService, private dialog: MatDialog, public imageService: ImageService) { }

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
    gender: "Male",
    avatar: null,
    email: null,
    phone: null,
    coverPhoto: null,
  };

  public username = "trung1";
 
  ngOnInit(): void {
    this.imageService.getProfileInfo(this.username).subscribe((response) => {
      this.profile.firstName = response.firstName,
      this.profile.lastName = response.lastName,
      this.profile.email = response.email,
      this.profile.gender = response.gender,
      this.profile.phone = response.phone,
      this.profile.dateOfBirth = response.dateOfBirth,
      this.profile.avatar = "https://localhost:44371/images/" + response.avatar,
      this.profile.coverPhoto = "https://localhost:44371/images/" + response.coverPhoto
    });
  }

  editProfile()
  {
    this.dialog.open(EditprofileComponent);
    
  }
}
