import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { EditprofileComponent } from '../editprofile/editprofile.component';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    private dialog: MatDialog,
    private http: HttpClient,
    private activatedRoute: ActivatedRoute
  ) {
    
  }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(
      query => {
        if(query && query.username) {
          // call api query by username
          this.accountService.getUserProfileInfo(query.username).subscribe(result => {
            console.log(result)
          });
        }
      }
    );
    // const url = `${environment.baseUrl + 'Users'}`;
    // this.http.get(url).subscribe(
    //   (result) => {
    //     console.log(result);
    //   },
    //   (error) => {}
    // );
  }

  public posts = { posts: null };

  public profile: {
    userId: number;
    firstName: any;
    lastName: any;
    username: any;
    dateOfBirth: any;
    gender: any;
    avatar: any;
    email: any;
    phone: any;
    coverPhoto: any;
  } = {
    userId: null,
    firstName: null,
    lastName: null,
    username: null,
    dateOfBirth: null,
    gender: null,
    avatar: '',
    email: null,
    phone: null,
    coverPhoto: '',
  };

  displayDate(date) {
    const months = [
      'January',
      'February',
      'March',
      'April',
      'May',
      'June',
      'July',
      'August',
      'September',
      'October',
      'November',
      'December',
    ];
    const d = new Date(date);
    const monthName = months[d.getMonth()];
    const day = d.getDate() < 10 ? '0' + d.getDate() : d.getDate();
    return monthName + ' ' + day;
  }

  editProfile() {
    this.dialog.open(EditprofileComponent);
  }

  displayModal(event: any) {
    event.stopPropagation();
    const wpContainer = document.querySelector('.wp-container');
    wpContainer.classList.remove('hidden');
    document.querySelector('body').style.overflowY = 'hidden';
  }

  closeModal(event: any) {
    if (!event.target.closest('.wp-child')) {
      const wpContainer = document.querySelector('.wp-container');
      wpContainer.classList.add('hidden');
      document.querySelector('body').style.overflowY = 'inherit';
    }
  }
}
