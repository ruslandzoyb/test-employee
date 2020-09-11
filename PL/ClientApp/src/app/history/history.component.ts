import { Component, OnInit } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {History} from "../shared/models/history";
import { Router } from '@angular/router';
import { from } from 'rxjs';
import { HistoryService } from '../shared/services/history.service';
import { MatDialog, MatDialogConfig } from "@angular/material";

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {
histories :History[];
  constructor(private service: HistoryService ,private router: Router) { 

  }

  ngOnInit() {
    this.gethistories();
  }

  gethistories(){
    this.service.getemployees().subscribe(res=>{this.histories=res as History[]});
  }

  OnCreatePosition(){

  }

}
