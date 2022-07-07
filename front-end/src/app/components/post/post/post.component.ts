import { Component, OnInit, Input } from '@angular/core';
import { PostService } from 'src/_services/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  constructor(private postService: PostService) {}

  @Input() avatar;
  @Input() firstName;
  @Input() lastName;
  @Input() status;
  @Input() image = '';
  @Input() date;
  @Input() userId;
  @Input() postId;

  displayDeleteButton() {
    const deleteBtn = document.querySelector('.delete-btn');

    if(deleteBtn.className.includes('hidden')) {
      deleteBtn.classList.remove('hidden');
    }
    else {
      deleteBtn.classList.add('hidden')
    }
  }

  deletePost() {
    this.postService.deletePost(this.userId, this.postId).subscribe((response) => {
      console.log(response)
      window.location.reload()
    }, error => console.log(error));
  }

  ngOnInit(): void {}
}
