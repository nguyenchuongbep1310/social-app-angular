import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
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
          .subscribe((response) => {
            this.profile = response;

            this.accountService
              .getPostSearchUser(this.profile.userId)
              .subscribe((response) => {
                this.posts = response.reverse();
              });
            this.getFriend();
          });
      }
    });
  }

  public addFriendBtn: boolean;

  public getFriend() {
    this.friendService
      .getFriend(this.currentUserProfile?.userId, this.profile?.userId)
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

  public posts;

  public profile;

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
