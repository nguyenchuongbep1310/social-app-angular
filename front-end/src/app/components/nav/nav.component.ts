import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/_services/account.service';
import { NotificationService } from 'src/_services/notification.service';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  constructor(
    private element: ElementRef,
    private _router: Router,
    public accountService: AccountService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.stickyBar();
    this.accountService.getCurrentUserProfile().subscribe({
      next: (response) => {
        this.profile = response;
        this.getNotificationCount();
        
      },
      error: (error) => console.log(error),
    });

    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Debug)
      .withUrl('https://localhost:44371/notify', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .build();

    connection
      .start()
      .then(function () {
        console.log('SignalR Connected!');
      })
      .catch(function (err) {
        return console.error(err.toString());
      });

    connection.on('BroadcastMessage', () => {
      this.getNotificationCount();
    });
  }

  public profile;
  searchQuery: string = '';

  hidden: string = 'hidden';
  menu: boolean = false;
  icon: string = 'M4 6h16M4 12h16M4 18h7';

  onClickHidden() {
    if (this.hidden === 'hidden') {
      this.hidden = '';
    } else {
      this.hidden = 'hidden';
    }
  }

  stickyBar() {
    window.onscroll = function () {
      var nav = document.querySelector('nav');
      var sticky = nav.offsetTop + 100;

      function myFunction() {
        if (window.pageYOffset > sticky) {
          nav.classList.add('sticky');
        } else {
          nav.classList.remove('sticky');
        }
      }

      myFunction();
    };
  }

  onMenuClick() {
    if (!this.menu) {
      this.element.nativeElement
        .querySelector('.first-column')
        .classList.add('translateX0');

      this.menu = true;
      this.icon = 'M6 18L18 6M6 6l12 12';
    } else {
      this.element.nativeElement
        .querySelector('.first-column')
        .classList.remove('translateX0');
      this.menu = false;
      this.icon = 'M4 6h16M4 12h16M4 18h7';
    }
  }

  logOut() {
    localStorage.removeItem('token');
    this._router.navigateByUrl('/login');
  }

  navigateToPersonalWall() {
    this._router.navigateByUrl('/personal-wall');
  }

  searchUser() {
    if (this.searchQuery && this.searchQuery.length > 0) {
      this.accountService
        .getProfileInfo(this.searchQuery)
        .subscribe((Response) => {
          if (Response) {
            this._router.navigateByUrl(
              `/search-user?username=${this.searchQuery}`
            );
          } else {
            alert('User does not exists!!!');
          }
        });
    }
  }

  @ViewChild('notificationItems') notificationItems;
  notificationBtnClick() {
    if (this.notificationItems.nativeElement.className.includes('hidden')) {
      this.notificationItems.nativeElement.classList.remove('hidden');
      this.getNotificationResult();
    } else {this.notificationItems.nativeElement.classList.add('hidden'); this.deleteNotification()};
  }

  // notification part
  notificationCount;
  getNotificationCount() {
    this.notificationService
      .getNotificationCount(this.profile?.userId)
      .subscribe({
        next: (notificationCount:any) => {this.notificationCount = notificationCount.count},
        error: (error) => console.log(error),
      });
  }

  notificationResult;
  getNotificationResult() {
    this.notificationService.getNotificationResult(this.profile?.userId).subscribe({
      next: (notificationResult: any) => {this.notificationResult = notificationResult},
      error: error => console.log(error)
    })
  }

  deleteNotification() {
    this.notificationService.deleteNotifications(this.profile?.userId).subscribe({
      next: response => {this.notificationCount = 0},
      error: error => console.log(error)
    })
  }
}
