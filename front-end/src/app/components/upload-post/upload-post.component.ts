import { Component, OnInit, Input } from '@angular/core';
import { PostService } from 'src/_services/post.service';

@Component({
  selector: 'app-upload-post',
  templateUrl: './upload-post.component.html',
  styleUrls: ['./upload-post.component.css'],
})
export class UploadPostComponent implements OnInit {
  constructor(private postService: PostService) {}

  @Input() avatar;
  @Input() fullName;
  @Input() userId;

  ngOnInit(): void {}

  image: any = '';
  loadFile(event: any) {
    document.querySelector('.img-upload').classList.remove('hidden');
    var image = document.getElementById('output');
    image.setAttribute('src', URL.createObjectURL(event.target.files[0]));
    this.image = event.target.files[0];
  }

  status: '';
  getStatus(event: any) {
    this.status = event.target.value;
  }

  addPost() {
    console.log(this.image);
    this.postService
      .createPost(this.userId, this.status, this.image)
      .subscribe((response) => {
        window.location.reload();
      });
  }
}
