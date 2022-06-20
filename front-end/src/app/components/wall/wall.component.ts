import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/_services/account.service';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';

@Component({
  selector: 'wall',
  templateUrl: './wall.component.html',
  styleUrls: ['./wall.component.css']
})
export class WallComponent implements OnInit {

  constructor( public accountService: AccountService, dialog: MatDialog) { }

  ngOnInit(): void {
  }

}
