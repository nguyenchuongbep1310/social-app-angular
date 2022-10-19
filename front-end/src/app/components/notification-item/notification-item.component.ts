import { Component, Input, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';

@Component({
  selector: 'notification-item',
  templateUrl: './notification-item.component.html',
  styleUrls: ['./notification-item.component.css']
})
export class NotificationItemComponent implements OnInit {
  @Input() result;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.accountService.getUserProfileByUserId(this.result?.userSend).subscribe({
      next: response => this.userSend = response,
      error: error => console.log(error)
    })
    this.accountService.getUserProfileByUserId(this.result?.userReceive).subscribe({
      next: response => this.userReceive = response,
      error: error => console.log(error)
    })
  }

  userSend;
  userReceive;

}
