import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { EditprofileComponent } from '../editprofile/editprofile.component';

@Component({
  selector: 'wall',
  templateUrl: './wall.component.html',
  styleUrls: ['./wall.component.css']
})
export class WallComponent implements OnInit {

  constructor( public accountService: AccountService, private dialog: MatDialog) { }


  ngOnInit(): void {
  }

  editProfile()
  {
    this.dialog.open(EditprofileComponent);
    
  }
}
