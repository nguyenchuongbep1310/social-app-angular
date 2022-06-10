import { Component, OnInit, ElementRef } from '@angular/core';
import { of, throwIfEmpty } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  constructor(private element: ElementRef) {}

  ngOnInit(): void {}

  hidden: string = 'hidden';
  menu: boolean = false;
  icon: string = 'M4 6h16M4 12h16M4 18h7';

  onClickHidden() {
    if (this.hidden === 'hidden') {
      this.hidden = '';
    } else {
      this.hidden = 'hidden';
    }
  }

  onMenuClick() {
    if (!this.menu) {
      this.element.nativeElement
        .querySelector('.first-column')
        .classList.add('translateX0');

      this.menu = true;
      this.icon = 'M6 18L18 6M6 6l12 12';
    } else {
      this.element.nativeElement
        .querySelector('.first-column')
        .classList.remove('translateX0');
      this.menu = false;
      this.icon = 'M4 6h16M4 12h16M4 18h7';
    }
  }
}
