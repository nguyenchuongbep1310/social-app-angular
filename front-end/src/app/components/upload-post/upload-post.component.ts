import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-upload-post',
  templateUrl: './upload-post.component.html',
  styleUrls: ['./upload-post.component.css'],
})
export class UploadPostComponent implements OnInit {
  constructor() {}

  @Input() avatar;
  @Input() fullName;

  ngOnInit(): void {}

  loadFile(event: any) {
    document.querySelector('.img-upload').classList.remove('hidden');
    var image = document.getElementById('output');
    image.setAttribute('src', URL.createObjectURL(event.target.files[0]));
  }
}
