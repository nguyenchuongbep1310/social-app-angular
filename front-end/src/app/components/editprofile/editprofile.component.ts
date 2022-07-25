import { Component, ElementRef, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/_services/account.service';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';

@Component({
  selector: 'editprofile',
  templateUrl: './editprofile.component.html',
  styleUrls: ['./editprofile.component.css'],
})
export class EditprofileComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    private _router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.accountService.getCurrentUserProfile().subscribe({
      next: (response) => {
        this.currentUserProfile = response;
      },
      error: (error) => console.log(error),
    });
  }

  public currentUserProfile;

  public formatDate() {
    if (this.currentUserProfile.dateOfBirth) {
      var d = this.currentUserProfile.dateOfBirth.split('/');
      const dateFormat = d.reverse().join('-');

      return dateFormat;
    }
    return;
  }

  public hitCancel: boolean = false;

  public getInput(event: Event, currentUserProfile: any, str: string) {
    currentUserProfile[str] = (event.target as HTMLInputElement).value;
  }

  public blur(currentUserProfile: any, str: string) {
    if (currentUserProfile[str] === null) currentUserProfile[str] = '';
  }

  public navigateToLogin() {
    this._router.navigateByUrl('/login');
  }

  onNoClick(): void {
    this.dialog.closeAll();
  }

  onFileChanged(event: any, s: string) {
    this.currentUserProfile[s] = event.target.files[0];
  }

  onSave() {
    this.onEditProfile();
  }

  public onEditProfile(): void {
    if (this.currentUserProfile.dateOfBirth.includes('-')) {
      let myDate = new Date(this.currentUserProfile.dateOfBirth);
      let date = myDate.toLocaleDateString('en-AU');

      this.currentUserProfile.dateOfBirth = date;
    }
    this.accountService
      .editProfile(this.currentUserProfile)
      .subscribe((response) => {
        location.reload();
      });
  }
}
