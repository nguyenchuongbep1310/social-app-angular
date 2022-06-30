import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { EditprofileComponent } from '../editprofile/editprofile.component';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'wall',
  templateUrl: './wall.component.html',
  styleUrls: ['./wall.component.css'],
})
export class WallComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    private dialog: MatDialog,
    private http: HttpClient
  ) {
    this.accountService.getPosts(this.profile, this.posts);
    console.log(this.posts);
  }

  ngOnInit(): void {
    const url = `${environment.baseUrl + 'Users'}`;
    this.http.get(url).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {}
    );
  }

  public posts = { posts: null };

  public profile: {
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

  editProfile() {
    this.dialog.open(EditprofileComponent);
  }

  displayModal(event: any) {
    event.stopPropagation();
    const wpContainer = document.querySelector('.wp-container');
    wpContainer.classList.remove('hidden');
  }

  closeModal(event: any) {
    const wpContainer = document.querySelector('.wp-container');
    if (!event.target.closest('.wp-child')) {
      wpContainer.classList.add('hidden');
    }
  }
}
