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

  ngOnInit(): void {
    console.log(this.posts);
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
  }

  closeModal(event: any) {
    const wpContainer = document.querySelector('.wp-container');
    if (!event.target.closest('.wp-child')) {
      wpContainer.classList.add('hidden');
    }
  }
}
