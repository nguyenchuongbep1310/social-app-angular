import { Component, ElementRef, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/_services/account.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'editprofile',
  templateUrl: './editprofile.component.html',
  styleUrls: ['./editprofile.component.css']
})
export class EditprofileComponent implements OnInit {

  constructor(
    private elRef: ElementRef,
    public accountService: AccountService,
    private _router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
  }
  public value: {
    firstName: any;
    lastName: any;
    username: any;
    password: any;
    confirmPassword: any;
    dateOfBirth: any;
    gender: any;
    avatar: any;
    email: any;
    phone: any;
  } = {
    firstName: null,
    lastName: null,
    username: null,
    password: null,
    confirmPassword: null,
    dateOfBirth: null,
    gender: "Male",
    avatar: null,
    email: null,
    phone: null,
  };
  public hitCancel:boolean=false;

  public getInput(event: Event, value: any, str: string) {
    value[str] = (event.target as HTMLInputElement).value;
  }

  public blur(value: any, str: string) {
    if (value[str] === null) value[str] = '';
  }

  public navigateToLogin() {
    this._router.navigateByUrl('/login');
  }

  onNoClick(): void {
    this.dialog.closeAll()
  }
 


  public onSubmitRegister(): void {
    let myDate = new Date(this.value.dateOfBirth);
    let date = myDate.toLocaleDateString('en-AU');

    this.value.dateOfBirth = date;

    // this.accountService.register(this.value).subscribe((response) => {
    //   if (response.success == true) {              
    //     alert("Your account has been created successfully.");
    //     this.navigateToLogin();
    //   }
    // });    
  }
}
