import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  constructor() {}

  @Input() avatar;
  @Input() firstName;
  @Input() lastName;
  @Input() status;
  @Input() image = '';
  @Input() date;

  ngOnInit(): void {}
}
