import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { PostService } from 'src/_services/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  constructor(private postService: PostService) {}

  @ViewChild('deleteBtn') deleteBtn;

  @Input() avatar;
  @Input() firstName;
  @Input() lastName;
  @Input() status = '';
  @Input() image = '';
  @Input() date;
  @Input() userId;
  @Input() postId;
  @Input() displayDeleteBtn;

  displayDeleteButton() {
    if (this.deleteBtn.nativeElement.className.includes('hidden')) {
      this.deleteBtn.nativeElement.classList.remove('hidden');
    } else {
      this.deleteBtn.nativeElement.classList.add('hidden');
    }
  }

  deletePost() {
    this.postService.deletePost(this.userId, this.postId).subscribe(
      (response) => {
        console.log(response);
        window.location.reload();
      },
      (error) => console.log(error)
    );
  }

  ngOnInit(): void {
    console.log(this.image);
  }
}
