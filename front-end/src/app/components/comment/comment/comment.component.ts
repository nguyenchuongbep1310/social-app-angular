import { Component, Input, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';

@Component({
  selector: 'comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css'],
})
export class CommentComponent implements OnInit {
  @Input() avatar;
  @Input() commentId;
  @Input() text;
  @Input() commentUserId;
  @Input() postId;

  public commentUserProfile;
  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.accountService.getUserProfileByUserId(this.commentUserId).subscribe({
      next: (response) => {
        this.commentUserProfile = response;
      },
      error: (error) => console.log(error),
    });
  }
}
