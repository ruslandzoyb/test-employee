import { Component, OnInit } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {History} from "../shared/models/history";
import { Router } from '@angular/router';
import { from } from 'rxjs';
import { HistoryService } from '../shared/services/history.service';
import { MatDialog, MatDialogConfig } from "@angular/material";
import {EmployeeComponent} from "../employee/employee.component"
import { relative } from 'path';
import { Position } from '../shared/models/position';
import { PositionComponent } from '../position/position.component';


@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {
histories :History[];


  constructor(private service: HistoryService ,private router: Router, private dialog: MatDialog) { 

  }

  ngOnInit() {
    this.gethistories();
  }

  gethistories(){
    this.service.getemployees().subscribe(res=>{this.histories=res as History[]});
  }

  AddPosition(){
  
  const dialogConfig = new MatDialogConfig();
    
  dialogConfig.width="25%";
  dialogConfig.height="25%";
    
    this.dialog.open(PositionComponent,dialogConfig);

    }

    AddEmployee(){
      const dialogConfig = new MatDialogConfig();

    dialogConfig.width="50%";
    dialogConfig.height="75%";
    
    this.dialog.open(EmployeeComponent,dialogConfig);
  
    
    }
  }


