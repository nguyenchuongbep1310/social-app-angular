import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AccountService } from 'src/_services/account.service';
import { LikeCommentService } from 'src/_services/like-comment.service';

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
  @Input() arrayOfComments;

  public commentUserProfile;
  constructor(
    private accountService: AccountService,
    private likeCommentService: LikeCommentService
  ) {
    this.commentSubject$.subscribe((response) => {});
  }

  public commentSubject$: Subject<object> = new Subject<object>();

  ngOnInit(): void {
    this.accountService.getUserProfileByUserId(this.commentUserId).subscribe({
      next: (response) => {
        this.commentUserProfile = response;
      },
      error: (error) => console.log(error),
    });
  }

  deleteComment() {
    this.likeCommentService
      .deleteComment(this.commentId, this.commentUserId)
      .subscribe({
        next: (response) => {
          this.likeCommentService.getComments(this.postId).subscribe({
            next: (response: any[]) => {
              this.arrayOfComments = response;
              this.commentSubject$.next(this.arrayOfComments);
            },
            error: (error) => console.log(error),
          });
        },
        error: (error) => console.log(error),
      });
  }
}
