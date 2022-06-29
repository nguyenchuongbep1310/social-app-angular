import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-upload-post',
  templateUrl: './upload-post.component.html',
  styleUrls: ['./upload-post.component.css'],
})
export class UploadPostComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  loadFile(event: any) {
    var image = document.getElementById('output');
    console.log(image.getAttribute('src'));
    image.setAttribute('src', URL.createObjectURL(event.target.files[0]));
    console.log(image.getAttribute('src'));
  }
}
