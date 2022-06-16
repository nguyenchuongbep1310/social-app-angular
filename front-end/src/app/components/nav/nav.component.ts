import { Component, OnInit, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { of, throwIfEmpty } from 'rxjs';
import { AccountService } from 'src/_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  constructor(
    private element: ElementRef,
    private _router: Router,
    public accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.stickyBar();
  }

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

  stickyBar() {
    const nav = document.querySelector('nav');
    const navHeight = nav.getBoundingClientRect().height;
    const container = document.querySelector('.container');

    const stickyNav = function (entries) {
      const [entry] = entries;

      if (!entry.isIntersecting) nav.classList.add('sticky');
      else nav.classList.remove('sticky');
    };

    const navObserver = new IntersectionObserver(stickyNav, {
      root: null,
      threshold: 0,
      rootMargin: `-${navHeight}px`,
    });

    navObserver.observe(container);
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

  logOut() {
    localStorage.removeItem('token')
    this._router.navigateByUrl('/login');
  }
}
