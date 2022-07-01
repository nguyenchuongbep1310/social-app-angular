import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import { PostService } from 'src/_services/post.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    public postService: PostService
  ) {
    this.accountService.getPosts(this.profile, this.posts);
  }

  ngOnInit(): void {}

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

  public posts = { posts: null };

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

  displayModal(event: any) {
    event.stopPropagation();
    const wpContainer = document.querySelector('.wp-container');
    wpContainer.classList.remove('hidden');
    document.querySelector('body').style.overflowY = 'hidden';
  }

  closeModal(event: any) {
    if (!event.target.closest('.wp-child')) {
      const wpContainer = document.querySelector('.wp-container');
      wpContainer.classList.add('hidden');
      document.querySelector('body').style.overflowY = 'inherit';
    }
  }
}
