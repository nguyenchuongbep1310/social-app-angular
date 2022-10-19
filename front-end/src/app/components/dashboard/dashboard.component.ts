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
  ) {}

  public currentUserProfile;

  ngOnInit(): void {
    this.getCurrentUserProfileAndPostsOfFriends();
  }

  getCurrentUserProfileAndPostsOfFriends() {
    this.accountService.getCurrentUserProfile().subscribe({
      next: (response) => {
        this.currentUserProfile = response;
        this.postService.getPostsAndFriendPosts(response.userId).subscribe({
          next: (response) => {
            this.posts = response;
          },
          error: (error) => console.log(error),
        });
      },
      error: (error) => console.log(error),
    });
  }

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

  public posts;

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
