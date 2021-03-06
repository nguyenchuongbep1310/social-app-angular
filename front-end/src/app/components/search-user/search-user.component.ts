import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { EditprofileComponent } from '../editprofile/editprofile.component';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { FriendService } from 'src/_services/friend.service';

@Component({
  selector: 'search',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.css'],
})
export class SearchUserComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    private activatedRoute: ActivatedRoute,
    private _router: Router,
    private friendService: FriendService
  ) {}

  public currentUserProfile;

  ngOnInit(): void {
    this.accountService.getCurrentUserProfile().subscribe({
      next: (response) => {
        this.currentUserProfile = response;
      },
      error: (error) => console.log(error),
    });
    this.activatedRoute.queryParams.subscribe((query) => {
      if (query && query.username) {
        if (query.username === this.accountService.userName) {
          this.navigateToPersonalWall();
        }

        // call api query by username
        this.accountService
          .getProfileInfo(query.username)
          .subscribe((Response) => {
            this.profile.userId = Response.userId;
            this.profile.firstName = Response.firstName;
            this.profile.lastName = Response.lastName;
            this.profile.username = Response.userName;
            this.profile.dateOfBirth = Response.dateOfBirth;
            this.profile.gender = Response.gender;
            this.profile.avatar = Response.avatar
              ? 'https://localhost:44371/Images/' + Response.avatar
              : '';
            this.profile.email = Response.email;
            this.profile.phone = Response.phone;
            this.profile.coverPhoto = Response.coverPhoto
              ? 'https://localhost:44371/Images/' + Response.coverPhoto
              : '';

            this.accountService
              .getPostSearchUser(this.profile.userId)
              .subscribe((Response) => {
                this.posts.posts = Response.reverse();
              });
            this.getFriend();
          });
      }
    });
  }

  public addFriendBtn: boolean;

  public getFriend() {
    this.friendService
      .getFriend(this.currentUserProfile.userId, this.profile.userId)
      .subscribe({
        next: (response: any) => {
          if (response) {
            this.addFriendBtn = true;
          } else {
            this.addFriendBtn = false;
          }
        },
        error: (error) => console.log(error),
      });
  }

  public posts = { posts: [] };

  public profile: {
    userId: number;
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
    userId: null,
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

  displayDate(date) {
    const months = [
      'January',
      'February',
      'March',
      'April',
      'May',
      'June',
      'July',
      'August',
      'September',
      'October',
      'November',
      'December',
    ];
    const d = new Date(date);
    const monthName = months[d.getMonth()];
    const day = d.getDate() < 10 ? '0' + d.getDate() : d.getDate();
    return monthName + ' ' + day;
  }

  navigateToPersonalWall() {
    this._router.navigateByUrl('/personal-wall');
  }

  public addFriend() {
    this.friendService.addFriend(this.profile.username).subscribe({
      next: (response) => {
        window.location.reload();
      },
      error: (error) => console.log(error),
    });
  }

  public unFriend() {
    this.friendService.unFriend(this.profile.username).subscribe({
      next: (response) => {
        window.location.reload();
      },
      error: (error) => console.log(error),
    });
  }
}
