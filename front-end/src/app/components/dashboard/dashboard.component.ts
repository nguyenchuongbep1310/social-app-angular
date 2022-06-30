import { Component } from '@angular/core';
import { AccountService } from 'src/_services/account.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent {
  constructor(public accountService: AccountService) {
    this.accountService.getProfile(this.profile);
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

  displayModal(event: any) {
    event.stopPropagation();
    const wpContainer = document.querySelector('.wp-container');
    wpContainer.classList.remove('hidden');
  }

  closeModal(event: any) {
    const wpContainer = document.querySelector('.wp-container');
    if (!event.target.closest('.wp-child')) {
      wpContainer.classList.add('hidden');
    }
  }
}
