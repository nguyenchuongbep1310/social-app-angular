import { Component, OnInit, Input, ViewChild, OnChanges } from '@angular/core';
import { PostService } from 'src/_services/post.service';
import { LikeCommentService } from 'src/_services/like-comment.service';
import { Subject } from 'rxjs';
import { AccountService } from 'src/_services/account.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  constructor(
    private postService: PostService,
    private likeCommentService: LikeCommentService = null,
    private accountService: AccountService //để tạm null để test
  ) {
    this.commentSubject$.subscribe((response) => {});
    this.likeSubject$.subscribe((response) => {});
  }

  ngOnChanges() {
    console.log(this.arrayOfComments);
  }

  ngOnInit(): void {
    this.accountService.getUserProfileByUserId(this.post.userId).subscribe({
      next: (response) => {
        this.postUserProfile = response;
      },
      error: (error) => console.log(error),
    });
    this.countLikes();
    this.likeCommentService.getComments(this.post.id).subscribe({
      next: (response: any[]) => {
        this.arrayOfComments = response;
      },
      error: (error) => console.log(error),
    });

    this.likeCommentService
      .getLikeOfCurrentUser(this.currentUserId, this.post.id)
      .subscribe((response) => {
        if (response != null && response.status === 'Actived') {
          this.likeBtnIcon.nativeElement.classList.add('application-color');
        }
      });
  }
  @ViewChild('textarea') textarea;
  @ViewChild('deleteBtn') deleteBtn;
  @ViewChild('likeBtnIcon') likeBtnIcon;

  @Input() post;
  @Input() date;
  @Input() displayDeleteBtn;
  @Input() currentUserId;
  @Input() currentUserAvatar;

  public commentSubject$: Subject<object> = new Subject<object>();
  public likeSubject$: Subject<number> = new Subject<number>();
  public arrayOfComments;
  public postUserProfile;

  displayDeleteButton() {
    if (this.deleteBtn.nativeElement.className.includes('hidden')) {
      this.deleteBtn.nativeElement.classList.remove('hidden');
    } else {
      this.deleteBtn.nativeElement.classList.add('hidden');
    }
  }

  deletePost() {
    this.postService.deletePost(this.post.userId, this.post.id).subscribe(
      (response) => {
        window.location.reload();
      },
      (error) => console.log(error)
    );
  }

  likeBtnClick() {
    if (
      this.likeBtnIcon.nativeElement.className.includes('application-color')
    ) {
      this.likeBtnIcon.nativeElement.classList.remove('application-color');
    } else {
      this.likeBtnIcon.nativeElement.classList.add('application-color');
    }

    this.postLike();

    // this.likeCommentService.postLike();
  }

  public totalLikes = 0;

  countLikes() {
    this.likeCommentService.countLikes(this.post.id).subscribe({
      next: (response: any) => {
        this.totalLikes = response.likesOfPostNumber;
      },
      error: (error) => console.log(error),
    });
  }

  postLike() {
    this.likeCommentService
      .getLikeOfCurrentUser(this.currentUserId, this.post.id)
      .subscribe((response) => {
        if (response === null) {
          this.likeCommentService
            .postLike(this.currentUserId, this.post.id)
            .subscribe({
              next: (response) => {
                this.countLikes();
                this.likeSubject$.next(this.totalLikes);
              },
              error: (error) => {
                console.log(error.error.errors.$[0]);
              },
            });
        }

        if (response != null && response.status === 'Actived') {
          this.likeCommentService.deleteLike(response.id).subscribe({
            next: (response) => {
              this.countLikes();
              this.likeSubject$.next(this.totalLikes);
            },
            error: (error) => console.log(error),
          });
        }
      });
  }

  areCommentsDisplayed = false;
  displayComments() {
    this.areCommentsDisplayed = !this.areCommentsDisplayed;
  }

  public commentContent;
  postComment() {
    if (!this.commentContent) return;
    this.likeCommentService
      .postComment(this.commentContent, this.currentUserId, this.post.id)
      .subscribe({
        next: (response) => {
          this.likeCommentService.getComments(this.post.id).subscribe({
            next: (response: any[]) => (this.arrayOfComments = response),
            error: (error) => console.log(error),
          });
        },
        error: (error) => console.log(error),
      });

    this.commentSubject$.next(this.arrayOfComments);
    this.textarea.nativeElement.value = '';
    this.commentContent = '';
    this.areCommentsDisplayed = true;
  }

  getInput(event: Event) {
    this.commentContent = (event.target as HTMLInputElement).value;
  }
}
