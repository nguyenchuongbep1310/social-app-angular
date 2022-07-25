import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { EditprofileComponent } from '../editprofile/editprofile.component';
import { PostService } from 'src/_services/post.service';

@Component({
  selector: 'wall',
  templateUrl: './wall.component.html',
  styleUrls: ['./wall.component.css'],
})
export class WallComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    private dialog: MatDialog,
    private postService: PostService
  ) {}

  ngOnInit(): void {
    this.accountService.getCurrentUserProfile().subscribe({
      next: (response) => {
        this.currentUserProfile = response;
        this.postService.getPosts(response.userId).subscribe({
          next: (response) => {
            this.posts = response;
          },
          error: (error) => console.log(error),
        });
      },
    });
  }

  public posts;

  public currentUserProfile;

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

  editProfile() {
    this.dialog.open(EditprofileComponent);
  }

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
